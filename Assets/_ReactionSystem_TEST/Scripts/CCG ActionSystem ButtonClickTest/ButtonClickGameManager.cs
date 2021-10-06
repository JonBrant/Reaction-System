using System;
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.AspectContainer;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.Assertions;


namespace ButtonClickTestScene {
    public class ButtonClickGameManager : Singleton<ButtonClickGameManager> {
        public ActionSystem ActionSystem;
        public Container Container;

        private void Awake() {
            Container = new Container();
            ActionSystem = Container.AddAspect<ActionSystem>();

            //ActionSystem.AddObserver(OnSequenceBegin,ActionSystem.beginSequenceNotification);
            //ActionSystem.AddObserver(OnSequenceEnd,ActionSystem.endSequenceNotification);
            Container.Awake();
        }

        private void Update() { ActionSystem.Update(); }

        void OnSequenceBegin(object sender,object args) {
            //Debug.LogFormat("ButtonClickGameManager.OnSequenceBegin()");
        }

        private void OnSequenceEnd(object sender,object args) {
            //Debug.LogFormat("ButtonClickGameManager.OnSequenceEnd()");
        }
    }
}