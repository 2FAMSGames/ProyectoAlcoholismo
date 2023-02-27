using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fusion;
using Photon.Realtime;
using Unity.VisualScripting;
using UnityEngine;
using NetworkBehaviour = Unity.Netcode.NetworkBehaviour;

public class GameState : NetworkBehaviour
{
    // singleton
    public static GameState instance;
    
    //[Networked]
    public Dictionary<string, PlayerData> GameplayState;

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
                Destroy(gameObject);
        }
        
    }

    public void AddPlayer(string playerName, ulong playerId)
    {
        if (GameplayState.ContainsKey(playerName)) return;

        GameplayState[playerName] = new PlayerData(playerName, playerId);
    }

    public void RemovePlayer(string playerName)
    {
        if (!GameplayState.ContainsKey(playerName)) return;

        GameplayState.Remove(playerName);
    }

    public void modifyPlayerScore(string playerName, int score)
    {
        if (!GameplayState.ContainsKey(playerName)) return;
        
        var currentScore = GameplayState[playerName].playerScore + score;
        currentScore = Math.Min(100, Math.Max(0, currentScore));

        GameplayState[playerName].playerScore = currentScore;
    }

    public void modifyPlayerName(string oldName, string newName)
    {
        if (!GameplayState.ContainsKey(oldName) || GameplayState.ContainsKey(newName)) return;

        GameplayState[newName] = GameplayState[oldName];
        GameplayState.Remove(oldName);
    }
    
    List<PlayerData> getScores()
    {
        var results = GameplayState.Values.ToList();
        results.Sort();

        return results;
    }
    
}
