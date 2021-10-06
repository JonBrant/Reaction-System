using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TheLiquidFire.Notifications;
using TheLiquidFire.AspectContainer;
using UnityEngine;
using UnityEngine.UI;


namespace ButtonClickTestScene {
    public class ButtonClickReaction : GameAction {
        public Text ButtonTextReference;
        public float Duration = 1;
    }

    public class ButtonClickActionReactionTest : MonoBehaviour {
        private void Awake() { this.AddObserver(OnPerform,Global.PerformNotification<ButtonClickAction>()); }

        private void OnDisable() { this.RemoveObserver(OnPerform,Global.PerformNotification<ButtonClickAction>()); }

        private void OnPerform(object sender,object args) {
            Debug.LogFormat("ButtonClickActionReactionTest.OnPerform()");
            ButtonClickAction action = args as ButtonClickAction;
            IContainer senderContainer = sender as IContainer;
            ButtonClickReaction reaction = new ButtonClickReaction();
            reaction.ButtonTextReference = action.ButtonTextReference;
            reaction.perform.viewer = ButtonClickActionReactionViewer;
            senderContainer.GetAspect<ActionSystem>().AddReaction(reaction);
        }

        private IEnumerator ButtonClickActionReactionViewer(IContainer sender,GameAction args) {
            if (args is ButtonClickReaction action) {
                string startingText = action.ButtonTextReference.text;
                float duration = action.Duration;
                float startTime = Time.time;

                while (Time.time - startTime < duration) {
                    float elapsed = Time.time - startTime;
                    float percent = elapsed / duration;
                    int currentIndex = Mathf.FloorToInt(startingText.Length * percent);
                    action.ButtonTextReference.text = "<color=red>" + startingText.Substring(0,currentIndex) + "</color>";
                    yield return null;
                }

                action.ButtonTextReference.text = startingText;
            } else {
                if (args != null) {
                    Debug.LogFormat("Invalid GameAction! Type: {0}",args.GetType());
                } else {
                    Debug.LogFormat("Invalid GameAction! Null?");
                }

                yield return null;
            }

            yield return null;
        }
    }
}