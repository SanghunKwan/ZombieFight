using System;
using UnityEngine;

namespace SGA.UI
{

    [CreateAssetMenu(fileName = "SliderNToggle", menuName = "Scriptable Objects/SliderNToggle")]
    public class SliderNToggle : ScriptableObject
    {
        public float[] sliderValue;
        public bool[] toggleValue;
        public Action<int> toggleChangeAction { get; set; }
        public Action<int> sliderChangeAction { get; set; }
        public void SetSize(int sliderSize, int toggleSize)
        {
            sliderValue = new float[sliderSize];
            toggleValue = new bool[toggleSize];
        }

        public void SetSliderValue(int index, float value)
        {
            sliderValue[index] = value;
            sliderChangeAction?.Invoke(index);
        }
        public void SetToggleValue(int index, bool value)
        {
            toggleValue[index] = value;
            toggleChangeAction?.Invoke(index);
        }
        public void CopySize(SliderNToggle otherObject)
        {
            toggleValue = new bool[otherObject.toggleValue.Length];
            sliderValue = new float[otherObject.sliderValue.Length];
        }
        public void CopyValue(SliderNToggle otherObject)
        {
            int length = otherObject.sliderValue.Length;
            for (int i = 0; i < length; i++)
            {
                sliderValue[i] = otherObject.sliderValue[i];

            }

            length = otherObject.toggleValue.Length;
            for (int i = 0; i < length; i++)
            {
                toggleValue[i] = otherObject.toggleValue[i];

            }
        }
    }
}
