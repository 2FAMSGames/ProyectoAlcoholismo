using System;
using System.Numerics;
using Fusion;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerBehaviour : NetworkBehaviour, IComparable<PlayerBehaviour>
{
    private NetworkCharacterControllerPrototype _cc;
    
    [Networked(OnChanged = nameof(OnPlayerNameChanged))]
    public string playerName { get; set; }
    
    [Networked(OnChanged = nameof(OnPlayerScoreChanged))]
    public int playerScore { get; set; }
    
    [Networked(OnChanged = nameof(OnPlayerColorChanged))]
    public Vector3 playerColor { get; set; }

    public string playerId { get; private set; }
    
    private void Awake()
    {
        _cc = GetComponent<NetworkCharacterControllerPrototype>();
    }

    public override void Spawned()
    {
        this.playerName = GameState.Instance.myPlayerName;
        this.playerId = GameState.Instance.uniqueID;
        this.playerColor = GameState.Instance.myPlayerColor;
        this.playerScore = 100;
        
        // --- Client
        // Find the local non-networked PlayerData to read the data and communicate it to the Host via a single RPC 
        if (Object.HasInputAuthority)
        {
            Debug.Log("enter client");
            RpcSetPlayerName(this.playerName);
            RpcSetPlayerColor(this.playerColor);
        }

        // --- Host
        // Initialized game specific settings
        if (Object.HasStateAuthority)
        {
            Debug.Log("enter host");
            GameState.Instance.AddPlayer(this.playerName, this);
        }
        
        Debug.Log("Player " + playerName + " spawned");
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        // Same as spawned
        // --- Host
        // Initialized game specific settings
        if (Object.HasStateAuthority)
        {
            // Things to do when this object despawns.
            GameState.Instance.RemovePlayer(this.playerName);
        }
    }
    
    public override void FixedUpdateNetwork()
    {
        // Get input and apply to the object.
        //if (GetInput(out NetworkInputData data))
        //{
        //    data.direction.Normalize();
        //    _cc.Move(5*data.direction*Runner.DeltaTime);
        //}
    }

    public static void OnPlayerNameChanged(Changed<PlayerBehaviour> changedInfo)
    {
        // Update local objects with the new name.
        Debug.Log(changedInfo.Behaviour.playerName + " OnPLayerNameChanged");
        //changedInfo.Behaviour.playerName
    }
    
    public static void OnPlayerScoreChanged(Changed<PlayerBehaviour> changedInfo)
    {
        // Update local objects with the new score
        Debug.Log(changedInfo.Behaviour.playerName + " OnPlayerScoreChanged");
        //changedInfo.Behaviour.playerScore
    }
    
    public static void OnPlayerColorChanged(Changed<PlayerBehaviour> changedInfo)
    {
        // Update local objects with the new color.
        Debug.Log(changedInfo.Behaviour.playerName + " OnPLayerColorChanged");
        //changedInfo.Behaviour.playerColor
    }

    public int CompareTo(PlayerBehaviour other)
    {
        if ( this.playerScore < other.playerScore ) return 1;
        else if ( this.playerScore > other.playerScore ) return -1;
        else return 0;
    }
    
    // RPCs used to send player information to the Host
    //
    [Rpc(sources: RpcSources.InputAuthority, targets: RpcTargets.StateAuthority)]
    private void RpcSetPlayerName(string name)
    {
        if (string.IsNullOrEmpty(name)) return;
        Debug.Log("Player " + playerName + " received new name " + name);
        playerName = name;
    }
    
    private void RpcSetPlayerColor(Vector3 color)
    {
        Debug.Log("Player " + playerName + " received color " + color.ToString());
        playerColor = color;
    }
    
    private void RpcSetPlayerScore(int score)
    {
        Debug.Log("Player " + playerName + " received score " + score);
        playerScore = score;
    }
}
