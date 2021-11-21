using UnityEngine;
using UnityEngine.Audio;

public class MixerSetter : MonoBehaviour
{
    [Header("Set In Inspector")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioMixerSnapshot initSnapshot;
    [SerializeField] private AudioMixerSnapshot pauseSnapshot;

    public void SetMasterVolume(float volume)
    {
        mixer.SetFloat("volumeMaster", volume);
    }
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("volumeMusic", volume);
    }
    public void SetFXVolume(float volume)
    {
        mixer.SetFloat("volumeFX", volume);
    }

    public void TogglePauseCutLP(bool pause)
    {
        float transitionTimeDelay = 0.001f; //when timescale == 0 this will stop transition alse, so need to set so low time to manage this
        if (pause)
        {
            pauseSnapshot.TransitionTo(transitionTimeDelay);
        }
        else
        {
            initSnapshot.TransitionTo(transitionTimeDelay);
        }
    }
}
