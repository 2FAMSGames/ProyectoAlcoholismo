using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject roomCreateMenu;
    [SerializeField]
    private GameObject roomJoinMenu;
    [SerializeField]
    private GameObject settingsMenu;

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
    }

    public void GoToRoomCreateMenu()
    {
        mainMenu.SetActive(false);
        roomCreateMenu.SetActive(true);
        roomJoinMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void GoToRoomJoinMenu()
    {
        mainMenu.SetActive(false);
        roomCreateMenu.SetActive(false);
        roomJoinMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void GoToSettingsMenu()
    {
        mainMenu.SetActive(false);
        roomCreateMenu.SetActive(false);
        roomJoinMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
