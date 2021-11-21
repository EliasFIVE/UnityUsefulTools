using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSountrackSet", menuName = "Options/SountrackSet", order = 2)]
public class SoundtrackSet_SO : ScriptableObject
{
    [SerializeField] private AudioClip introTrack;
    [SerializeField] private AudioClip gameOverTrack;
    [SerializeField] private List<AudioClip> ingameTrackList;

    public AudioClip GetIntroTrack()
    {
        return introTrack;
    }

    public AudioClip GetGameOverTrack()
    {
        return gameOverTrack;
    }
    public AudioClip GetTrackFromGameTrackList(int trackIndex)
    {
        return ingameTrackList[trackIndex];
    }

    public int GetSoundtrackListLength()
    {
        return ingameTrackList.Count;
    }
}
