using UnityEngine;
using UnityEngine.UIElements;

public class RoomCreateMenuController : MonoBehaviour {

    [SerializeField]
    private GameObject menusObject;
    private MenusController menusController;

    private UIDocument doc;
    private Button goBackButton;
    private Button createRoomButton;
    private TextField roomNameField;

    void OnEnable()
    {
        menusController = menusObject.GetComponent<MenusController>();

        doc = GetComponent<UIDocument>();

        goBackButton = doc.rootVisualElement.Q<Button>("GoBackButton");
        goBackButton.clicked += GoBackButtonOnClicked;

        createRoomButton = doc.rootVisualElement.Q<Button>("CreateButton");

        roomNameField = doc.rootVisualElement.Q<TextField>("RoomName");
        roomNameField.RegisterValueChangedCallback(OnEnterRoomName);
    }

    private void GoBackButtonOnClicked()
    {
        Debug.Log("Go back button clicked");
        menusController.GoToMainMenu();
    }

    private void OnEnterRoomName(ChangeEvent<string> changeEvent)
    {
        Debug.Log("Key pressed");
        Debug.Log("New value name: " + changeEvent.newValue);

    }
}
