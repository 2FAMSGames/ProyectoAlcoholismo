using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerItemController
{
    Label playerNameLabel;

    public void SetVisualElement(VisualElement ve)
    {
        playerNameLabel = ve.Q<Label>("PlayerName");
    }

    public void SetPlayerData(PlayerData pd)
    {
        playerNameLabel.text = pd.playerName;
    }
}
