using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Fusion;
using Photon.Realtime;
using Unity.Netcode;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject, IComparable<PlayerData>, INetworkSerializable
{ 
    public string playerName;
    public ulong playerId;
    public int playerScore;

    public PlayerData(string name, ulong id)
    {
        playerName = name;
        playerId = id;
        playerScore = 100;
    }
    
    public int CompareTo(PlayerData other)
    {
        if ( this.playerScore < other.playerScore ) return 1;
        else if ( this.playerScore > other.playerScore ) return -1;
        else return 0;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref playerName);
        serializer.SerializeValue(ref playerId);
        serializer.SerializeValue(ref playerScore);
    }
}
