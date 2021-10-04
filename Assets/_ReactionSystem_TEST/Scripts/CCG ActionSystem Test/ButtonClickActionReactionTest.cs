using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TheLiquidFire.Notifications;
using TheLiquidFire.AspectContainer;
using UnityEngine;


public class ButtonClickActionReactionTest : MonoBehaviour {
    private void Awake() { this.AddObserver(OnPerform,Global.PerformNotification<ButtonClickAction>()); }

    private void OnDisable() { this.RemoveObserver(OnPerform,Global.PerformNotification<ButtonClickAction>()); }

    private void OnPerform(object sender,object args) {
        Debug.LogFormat("ButtonClickActionReactionTest.OnPerform()");
        ButtonClickAction action = args as ButtonClickAction;
        IContainer senderContainer = sender as IContainer;
        ButtonClickAction reaction = new ButtonClickAction();
        reaction.ButtonTextReference = action.ButtonTextReference;
        reaction.perform.viewer = ButtonClickActionReactionViewer;
        senderContainer.GetAspect<ActionSystem>().AddReaction(reaction);
    }

    private IEnumerator ButtonClickActionReactionViewer(IContainer sender,GameAction args) {
        if (args is ButtonClickAction action) {
            string startingText = action.ButtonTextReference.text;
            float duration = 2;
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
            if (args is GameAction gameAction) {
                Debug.LogFormat("Invalid GameAction! Type: {0}",gameAction.GetType());
            } else {
                Debug.LogFormat("Invalid GameAction! Null?");
            }
            yield return null;
        }

        yield return null;
    }
}