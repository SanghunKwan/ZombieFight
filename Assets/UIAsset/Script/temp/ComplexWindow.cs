using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SGA.UI
{

    public class ComplexWindow : UIWindow
    {
        public ActionButton[] actionButtons;
        Dictionary<string, UnityEngine.UI.Button> keyButtonDictionary;
        public Action dataReroll { get; set; }

        public bool isChanged { get; set; }

        WindowManager windowManager;
        UIWindow cancelPopup;
        private void Start()
        {
            windowManager = transform.parent.GetComponent<WindowManager>();
            cancelPopup = windowManager.transform.Find("SettingCancelPopup").GetComponent<UIWindow>();

            UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
            keyButtonDictionary = new Dictionary<string, UnityEngine.UI.Button>();
            int length = actionButtons.Length;

            for (int i = 0; i < length; i++)
            {
                keyButtonDictionary.Add(actionButtons[i].actionName, actionButtons[i].button);
            }
            VisibleAction += ChangeReset;
        }

        public override void ActionTrigger(in InputAction.CallbackContext callbackContext)
        {
            if (!callbackContext.started || !keyButtonDictionary.ContainsKey(callbackContext.action.name))
                return;

            keyButtonDictionary[callbackContext.action.name].onClick.Invoke();
        }

        public void DataReroll()
        {
            dataReroll();
            ChangeReset();
        }
        public void OnCancelButtonClicked()
        {
            if (!isChanged)
                windowManager.CloseWindow(this);
            else
            {
                windowManager.OpenWindow(cancelPopup);
            }

        }
        public void ChangeReset()
        {
            isChanged = false;
        }
    }
}
