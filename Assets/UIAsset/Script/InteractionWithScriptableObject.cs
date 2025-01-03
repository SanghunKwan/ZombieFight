using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SGA.UI
{
    public class InteractionWithScriptableObject : MonoBehaviour
    {
        [SerializeField] SliderNToggle sliderNToggleObject;
        public SliderNToggle SliderNToggleObject { get { return sliderNToggleObject; } }

        [Space(10)]
        [SerializeField] UIWindow window;

        Toggle[] toggles;
        Slider[] sliders;
        int[] sibling2IndexToggle;
        int[] sibling2IndexSlider;

        [HideInInspector]
        public UsedChildNumber sliderUsingNum;
        [HideInInspector]
        public UsedChildNumber toggleUsingNum;

        public Action backupAction { get; set; }

        private void Awake()
        {

            toggles = transform.Find("Toggles").GetComponentsInChildren<Toggle>(true);
            sliders = transform.Find("Sliders").GetComponentsInChildren<Slider>(true);

            int sliderLength = sliders.Length;
            int toggleLength = toggles.Length;

            sibling2IndexSlider = new int[sliderLength];
            sibling2IndexToggle = new int[toggleLength];
        }
        private void Start()
        {
            window.VisibleAction += GetValue;

            PrepareValue("Toggles", toggleUsingNum, ref sibling2IndexToggle, (num) => SetValue(toggles[num]));

            PrepareValue("Sliders", sliderUsingNum, ref sibling2IndexSlider, (num) => SetValue(sliders[num]));
        }

        void PrepareValue(string contentName, UsedChildNumber usedChildNumber, ref int[] sibling2Index, in Action<int> setValue)
        {
            int index = 0;
            int enumIndex = 0;

            Transform contentTransform = transform.Find(contentName);

            while (GetActiveChildIndex(contentTransform, index, out index))
            {
                enumIndex = GetActiveEnumIndex(usedChildNumber, enumIndex);

                sibling2Index[index] = enumIndex;
                setValue(index);
                index++;
                enumIndex++;
            }
        }
        bool GetActiveChildIndex(Transform parentTransform, int startIndex, out int activeIndex)
        {
            int length = parentTransform.childCount;

            for (int i = startIndex; i < length; i++)
            {
                if (parentTransform.GetChild(i).gameObject.activeSelf)
                {
                    activeIndex = i;
                    return true;
                }
            }
            activeIndex = -1;
            return false;
            throw new NotImplementedException("Over Transform ChildCount");
        }
        int GetActiveEnumIndex(UsedChildNumber usedChildNumber, int startIndex)
        {
            int bitNum = (int)usedChildNumber >> startIndex;

            while (bitNum != 0)
            {
                if ((bitNum & 1) == 1)
                    return startIndex;

                bitNum >>= 1;
                startIndex++;
            }
            throw new NotImplementedException("Over enum Count");
        }

        public void SetValue(Toggle toggle)
        {
            sliderNToggleObject.SetToggleValue(sibling2IndexToggle[toggle.transform.GetSiblingIndex()], toggle.isOn);
        }
        public void SetValue(Slider slider)
        {
            sliderNToggleObject.SetSliderValue(sibling2IndexSlider[slider.transform.GetSiblingIndex()], slider.value);
        }

        void GetValue()
        {
            int length = toggles.Length;

            for (int i = 0; i < length; i++)
            {
                if (!toggles[i].gameObject.activeSelf)
                    continue;

                toggles[i].isOn = sliderNToggleObject.toggleValue[sibling2IndexToggle[i]];
            }

            length = sliders.Length;

            for (int i = 0; i < length; i++)
            {
                if (!sliders[i].gameObject.activeSelf)
                    continue;

                sliders[i].value = sliderNToggleObject.sliderValue[sibling2IndexSlider[i]];
            }
            backupAction?.Invoke();

        }

    }

    public enum UsedChildNumber
    {
        None,
        First,
        Second = 2,
        Third = 4,
        Fourth = 8,
        Fifth = 16,
        Sixth = 32,
        Seventh = 64,
        Eighth = 128,
        Ninth = 256,
        Tenth = 512
    }
}
