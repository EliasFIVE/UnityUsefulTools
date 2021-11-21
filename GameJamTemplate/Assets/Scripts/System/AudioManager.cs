using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Manager<AudioManager>
{
    private SoundtrackPlayer soundtrackPlayer;
    private MixerSetter mixerSetter;

    protected override void Awake()
    {
        base.Awake();
        soundtrackPlayer = GetComponent<SoundtrackPlayer>();
        mixerSetter = GetComponent<MixerSetter>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameStateSetter.GameState currentState, GameStateSetter.GameState previousState)
    {
        if(currentState == GameStateSetter.GameState.PAUSED || previousState == GameStateSetter.GameState.PAUSED)
            mixerSetter.TogglePauseCutLP(currentState == GameStateSetter.GameState.PAUSED);

        if (currentState == GameStateSetter.GameState.RUNNING && previousState != GameStateSetter.GameState.PAUSED)
            soundtrackPlayer.StartPlaySountrackList();

        if (currentState == GameStateSetter.GameState.INMENU)
            soundtrackPlayer.PlayIntroTrack();

        if (currentState == GameStateSetter.GameState.GAMEOVER)
            soundtrackPlayer.PlayGameOverTrack();
    }

    public void SetMasterVolume(float volume)
    {
        mixerSetter.SetMasterVolume(volume);
    }
    public void SetMusicVolume(float volume)
    {
        mixerSetter.SetMusicVolume(volume);
    }
    public void SetFXVolume(float volume)
    {
        mixerSetter.SetFXVolume(volume);
    }
}
