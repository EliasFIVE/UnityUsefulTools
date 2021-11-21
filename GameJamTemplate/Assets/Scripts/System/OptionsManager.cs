using UnityEngine;

public class OptionsManager : Manager<OptionsManager> 
{
    [Header("Set Dynamicaly")]
    [SerializeField] private OptionsSet_SO tempOptionsSet;

    private OptionsSetter optionsSetter;

    protected override void Awake()
    {
        base.Awake();
        optionsSetter = GetComponent<OptionsSetter>();
        tempOptionsSet = ScriptableObject.CreateInstance<OptionsSet_SO>();
    }

    void Start()
    {
        SetOptionsToDefaultValues();
    }
    public void SetOptionsToDefaultValues()
    {
        SetAllOptionsByOptionsSet(optionsSetter.DefaultOptionsSet);
    }
    public void CancelTempSettings()
    {
        SetAllOptionsByOptionsSet(optionsSetter.ActiveOptionsSet);
    }
    public void ApplyTempSettings()
    {
        optionsSetter.ChangeActiveOptionsSetValues(tempOptionsSet);
    }

    public void SetAllOptionsByOptionsSet(OptionsSet_SO optionsSet)
    {
        SetTemporaryMasterVolume(optionsSet.masterVolume);
        SetTemporaryMusicVolume(optionsSet.musicVolume);
        SetTemporaryFXVolume(optionsSet.soundFXVolume);
    }

    public void SetTemporaryMasterVolume(float volume)
    {
        tempOptionsSet.masterVolume = volume;
        AudioManager.Instance.SetMasterVolume(volume);
    }

    public void SetTemporaryMusicVolume(float volume)
    {
        tempOptionsSet.musicVolume = volume;
        AudioManager.Instance.SetMusicVolume(volume);
    }

    public void SetTemporaryFXVolume(float volume)
    {
        tempOptionsSet.soundFXVolume = volume;
        AudioManager.Instance.SetFXVolume(volume);
    }

    public OptionsSet_SO GetDefaultOtionsSet()
    {
        Debug.Log("GetDefaultOtionsSet");
        return optionsSetter.DefaultOptionsSet;
    }

    public OptionsSet_SO GetActiveOtionsSet()
    {
        return optionsSetter.ActiveOptionsSet;
    }
}
