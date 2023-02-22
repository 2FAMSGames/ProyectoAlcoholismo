using UnityEngine;
using UnityEngine.UIElements;

public class RoomJoinMenuController : MonoBehaviour {

    [SerializeField]
    private GameObject menusObject;
    private MenusController menusController;

    private UIDocument doc;
    private Button goBackButton;
    private Button joinRoomButton;

    private TextField playerNameField;
    private TextField roomNameField;

    void OnEnable()
    {
        menusController = menusObject.GetComponent<MenusController>();

        doc = GetComponent<UIDocument>();

        goBackButton = doc.rootVisualElement.Q<Button>("GoBackButton");
        goBackButton.clicked += GoBackButtonOnClicked;

        joinRoomButton = doc.rootVisualElement.Q<Button>("JoinButton");
        joinRoomButton.clicked += JoinRoomButtonOnClicked;

        roomNameField = doc.rootVisualElement.Q<TextField>("RoomName");
        roomNameField.RegisterValueChangedCallback(OnEnterRoomName);

        playerNameField = doc.rootVisualElement.Q<TextField>("PlayerName");
        playerNameField.RegisterValueChangedCallback(OnEnterRoomName);
    }

    private void GoBackButtonOnClicked()
    {
        Debug.Log("Go back button clicked");
        menusController.GoToMainMenu();
    }

    private void JoinRoomButtonOnClicked()
    {
        Debug.Log("Join room button clicked");
    }

    private void OnEnterRoomName(ChangeEvent<string> changeEvent)
    {
        Debug.Log("Room: Key pressed");
        menusController.ChangeNetworkRoomName(changeEvent.newValue);
    }

    private void OnEnterPlayerName(ChangeEvent<string> changeEvent)
    {
        Debug.Log("Player: Key pressed");
        menusController.ChangeNetworkPlayerName(changeEvent.newValue);
    }
}
