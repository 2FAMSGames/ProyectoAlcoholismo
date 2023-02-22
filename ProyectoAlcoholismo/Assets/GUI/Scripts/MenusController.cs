using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Netcode.Transports.PhotonRealtime;

public class MenusController : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject roomCreateMenu;
    [SerializeField]
    private GameObject roomJoinMenu;
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private GameObject roomMenu;

    [Header("Otros Gameobjects")]
    [SerializeField]
    private GameObject networkManager;
    private PhotonRealtimeTransport photonManager;

    void Start()
    {
        photonManager = networkManager.GetComponent<PhotonRealtimeTransport>();
    }

    void OnEnable()
    {
        GoToMainMenu();
    }

    public void GoToMainMenu()
    {
        mainMenu.SetActive(true);
        roomCreateMenu.SetActive(false);
        roomJoinMenu.SetActive(false);
        settingsMenu.SetActive(false);
        roomMenu.SetActive(false);
    }

    public void GoToRoomCreateMenu()
    {
        mainMenu.SetActive(false);
        roomCreateMenu.SetActive(true);
        roomJoinMenu.SetActive(false);
        settingsMenu.SetActive(false);
        roomMenu.SetActive(false);
    }

    public void GoToRoomJoinMenu()
    {
        mainMenu.SetActive(false);
        roomCreateMenu.SetActive(false);
        roomJoinMenu.SetActive(true);
        settingsMenu.SetActive(false);
        roomMenu.SetActive(false);
    }

    public void GoToSettingsMenu()
    {
        mainMenu.SetActive(false);
        roomCreateMenu.SetActive(false);
        roomJoinMenu.SetActive(false);
        settingsMenu.SetActive(true);
        roomMenu.SetActive(false);
    }

    public void GoToRoomMenu()
    {
        mainMenu.SetActive(false);
        roomCreateMenu.SetActive(false);
        roomJoinMenu.SetActive(false);
        settingsMenu.SetActive(false);
        roomMenu.SetActive(true);
    }

    public void ChangeNetworkRoomName(string newName)
    {
        photonManager.RoomName = newName;
    }

    public void ChangeNetworkPlayerName(string newName)
    {
        //Todo: Settear donde corresponda el player name para que sea visible por otros jugadores
    }

    
}
