using System;
using System.Collections;
using System.Collections.Generic;
using Com.PI.NotificationSystem;
using Com.PI.ReactionSystem;
using UnityEngine;


public class CommandButtonClickPacketData : ReactionPacket {
    public string CommandName;

    public CommandButtonClickPacketData(string inputCommandName = null) {
        CommandName = inputCommandName;
    }
}

public class CommandButtonUI : MonoBehaviour {
    private void Awake() { }

    public void OnButtonClick() {
        Debug.LogFormat("CommandButtonUI.OnButtonClick()");
        NotificationSystem<CommandButtonClickPacketData>.PostNotification("CommandButtonClicked",new CommandButtonClickPacketData {
            CommandName = "Test",OnReact = data => {
                Debug.LogFormat(data.);
            }
        });
    }
}