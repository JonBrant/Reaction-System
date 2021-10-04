using System;
using UnityEngine;

/*
namespace ReactionSystemPrototype {
    public class CommandButtonClickPacketData : ReactionPacket {
        public string CommandName;

        public CommandButtonClickPacketData(string inputCommandName = null) { CommandName = inputCommandName; }
    }

    public class CommandButtonUI_PROTOTYPE : MonoBehaviour {
        private void Awake() { NotificationSystem.AddObserver("CommandButtonClicked",OnButtonClick()); }

        public Action<PacketData> OnButtonClick() {
            Debug.LogFormat("CommandButtonUI_PROTOTYPE.OnButtonClick()");
            NotificationSystem.PostNotification("CommandButtonClicked",
                new CommandButtonClickPacketData {
                    OnValidate = delegate(PacketData data) { },
                    CommandName = "Test",
                    OnExecute = delegate(PacketData data) {
                        Debug.LogFormat(data.ToString());
                    }
                });
            return null;
        }
    }
}
*/