using UnityEngine;

[CreateAssetMenu(fileName = "NewOptionsSet", menuName = "Options/OptionsSet", order = 1)]
public class OptionsSet_SO : ScriptableObject
{
    [Header("Audio options")]
    public float masterVolume;
    public float musicVolume;
    public float soundFXVolume;

    public void ReplaceAllValues(OptionsSet_SO optionsSet)
    {
        masterVolume = optionsSet.masterVolume;
        musicVolume = optionsSet.musicVolume;
        soundFXVolume = optionsSet.soundFXVolume;
    }
}
