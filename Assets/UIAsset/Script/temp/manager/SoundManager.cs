using UnityEngine;
namespace SGA.Temp
{
    using System;
    using UI;

    public class SoundManager : MonoBehaviour
    {
        AudioSource audioSources;

        [SerializeField] SliderNToggle sliderNToggleData;
        Action[] toggleChangeAction;
        Action[] sliderChangeAction;


        private void Awake()
        {
            audioSources = GetComponent<AudioSource>();
            sliderNToggleData.toggleChangeAction += ToggleChangeAction;
            sliderNToggleData.sliderChangeAction += SliderChangeAction;


            SetAction();
        }
        void SetAction()
        {
            toggleChangeAction = new Action[6];
            toggleChangeAction[0] = () => { audioSources.mute = sliderNToggleData.toggleValue[0]; };
            toggleChangeAction[1] = () => { audioSources.bypassEffects = sliderNToggleData.toggleValue[1]; };
            toggleChangeAction[2] = () => { audioSources.bypassListenerEffects = sliderNToggleData.toggleValue[2]; };
            toggleChangeAction[3] = () => { audioSources.bypassReverbZones = sliderNToggleData.toggleValue[3]; };
            toggleChangeAction[4] = () => { audioSources.playOnAwake = sliderNToggleData.toggleValue[4]; };
            toggleChangeAction[5] = () => { audioSources.loop = sliderNToggleData.toggleValue[5]; };


            sliderChangeAction = new Action[6];
            sliderChangeAction[0] = () => { audioSources.priority = Mathf.RoundToInt(sliderNToggleData.sliderValue[0]); };
            sliderChangeAction[1] = () => { audioSources.volume = sliderNToggleData.sliderValue[1]; };
            sliderChangeAction[2] = () => { audioSources.pitch = sliderNToggleData.sliderValue[2]; };
            sliderChangeAction[3] = () => { audioSources.panStereo = sliderNToggleData.sliderValue[3]; };
            sliderChangeAction[4] = () => { audioSources.spatialBlend = sliderNToggleData.sliderValue[4]; };
            sliderChangeAction[5] = () => { audioSources.reverbZoneMix = sliderNToggleData.sliderValue[5]; };


        }
        public void ToggleChangeAction(int index)
        {
            toggleChangeAction[index]();
        }
        public void SliderChangeAction(int index)
        {
            sliderChangeAction[index]();
        }
    }
}
