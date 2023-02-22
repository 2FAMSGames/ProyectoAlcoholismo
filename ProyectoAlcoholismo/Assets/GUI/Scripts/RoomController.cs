using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomController : MonoBehaviour
{
    [SerializeField]
    private GameObject menusObject;
    private MenusController menusController;

    private UIDocument doc;
    private Button goBackButton;
    private ListView playerList;

    void OnEnable()
    {
        menusController = menusObject.GetComponent<MenusController>();

        doc = GetComponent<UIDocument>();

        goBackButton = doc.rootVisualElement.Q<Button>("GoBackButton");
        goBackButton.clicked += GoBackButtonOnClicked;

        playerList = doc.rootVisualElement.Q<ListView>("PlayerList");
    }

    private void GoBackButtonOnClicked()
    {
        Debug.Log("Go back button clicked");
        menusController.GoToMainMenu();
        //Desconectarse del host o eliminar la sala
    }
}
