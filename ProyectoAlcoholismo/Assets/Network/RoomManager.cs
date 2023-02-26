using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;



//Al unirse un jugador a la sala, se le a�ade a la lista de jugadores, y se le comparte una "copia de este objeto"


public class RoomManager : NetworkBehaviour
{
    public byte life { get; set; }
    private string roomName;
    private List<PlayerData> playerList;
    private List<Minigame> gamesList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
