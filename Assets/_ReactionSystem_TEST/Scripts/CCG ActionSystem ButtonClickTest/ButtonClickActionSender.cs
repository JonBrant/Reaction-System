using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TheLiquidFire.AspectContainer;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.UI;


namespace ButtonClickTestScene {
    public class ButtonClickAction : GameAction {
        public Text ButtonTextReference;
        public float Duration = 2;
    }

    public class ButtonClickActionSender : MonoBehaviour {
        public Text ButtonText;

        public void SendGameAction() {
            ButtonClickAction buttonClickAction = new ButtonClickAction();
            buttonClickAction.perform.viewer = ButtonClickActionPerformViewer;
            buttonClickAction.ButtonTextReference = ButtonText;
            ButtonClickGameManager.Instance.ActionSystem.Perform(buttonClickAction);
        }

        private IEnumerator ButtonClickActionPerformViewer(IContainer sender,GameAction args) {
            if (args is ButtonClickAction action) {
                string startingText = action.ButtonTextReference.text;
                float duration = action.Duration;
                float startTime = Time.time;

                while (Time.time - startTime < duration) {
                    float elapsed = Time.time - startTime;
                    float percent = elapsed / duration;
                    int currentIndex = Mathf.FloorToInt(startingText.Length * percent);
                    action.ButtonTextReference.text = startingText.Substring(0,currentIndex);
                    yield return null;
                }

                action.ButtonTextReference.text = startingText;
            } else {
                Debug.LogFormat("Invalid GameAction!");
            }

            yield return null;
        }
    }
}