using System.Collections;
using UnityEngine;

public class SoundtrackPlayer : MonoBehaviour
{
    [Header("Set In Inspector")]
    [SerializeField] private SoundtrackSet_SO soundrack;

    private AudioSource audioSource;
    
    [Header("Set Dynamicaly")]
    [SerializeField] private bool SountrackListIsPlaying = false;  
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void StartPlaySountrackList()
    {
        SountrackListIsPlaying = true;
        StartCoroutine(PlayTracksFromListInOrder(0));
    }

    private IEnumerator PlayTracksFromListInOrder(int index)
    {
        if (index >= soundrack.GetSoundtrackListLength())
            index = 0;

        AudioClip track = soundrack.GetTrackFromGameTrackList(index);
        PlayMusicTrack(track);

        yield return new WaitForSeconds(track.length);

        if(SountrackListIsPlaying)
            StartCoroutine(PlayTracksFromListInOrder(index + 1));
    }

    public void PlayIntroTrack()
    {
        SountrackListIsPlaying = false;
        PlayMusicTrack(soundrack.GetIntroTrack());
    }

    public void PlayGameOverTrack()
    {
        SountrackListIsPlaying = false;
        PlayMusicTrack(soundrack.GetGameOverTrack());
    }
    private void PlayMusicTrack(AudioClip track)
    {
        audioSource.Stop();
        audioSource.clip = track;
        audioSource.PlayDelayed(1f);
    }
}
