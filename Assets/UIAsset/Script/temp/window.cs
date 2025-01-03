using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace SGA.UI
{

    public class window : UIWindow
    {
        public ActionButton[] actionButtons;
        Dictionary<string, Button> keyButtonDictionary;
        private void Start()
        {
            keyButtonDictionary = new Dictionary<string, Button>();
            int length = actionButtons.Length;

            for (int i = 0; i < length; i++)
            {
                keyButtonDictionary.Add(actionButtons[i].actionName, actionButtons[i].button);
            }
        }

        public override void ActionTrigger(in InputAction.CallbackContext callbackContext)
        {
            if (!callbackContext.started || !keyButtonDictionary.ContainsKey(callbackContext.action.name))
                return;

            keyButtonDictionary[callbackContext.action.name].onClick.Invoke();
        }
    }
}
