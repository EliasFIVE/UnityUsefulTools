using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private Button applyButton;
    [SerializeField] private Button defaultButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundFXVolumeSlider;

    private void OnEnable()
    {
        SetControllersToActiveValues();
    }
    void Start()
    {
        applyButton.onClick.AddListener(HandleApplyClicked);
        cancelButton.onClick.AddListener(HandleCancelClicked);
        defaultButton.onClick.AddListener(HandleDefaultClicked);
        masterVolumeSlider.onValueChanged.AddListener(HandleMasterVolumeSlider);
        musicVolumeSlider.onValueChanged.AddListener(HandleMusicVolumeSlider);
        soundFXVolumeSlider.onValueChanged.AddListener(HandleSoundFXVolumeSlider);
    }

    private void HandleDefaultClicked()
    {
        SetControllersToDefaultValues();
        OptionsManager.Instance.SetOptionsToDefaultValues();
    }
    private void HandleCancelClicked()
    {
        SetControllersByOptionsSet(OptionsManager.Instance.GetActiveOtionsSet());
        OptionsManager.Instance.CancelTempSettings();
        UIManager.Instance.ToggleOptionsMenu();
    }
    private void HandleApplyClicked()
    {
        OptionsManager.Instance.ApplyTempSettings();
        UIManager.Instance.ToggleOptionsMenu();
    }
    public void HandleMasterVolumeSlider(float value)
    {
        OptionsManager.Instance.SetTemporaryMasterVolume(value);
    }
    public void HandleMusicVolumeSlider(float value)
    {
        OptionsManager.Instance.SetTemporaryMusicVolume(value);
    }
    public void HandleSoundFXVolumeSlider(float value)
    {
        OptionsManager.Instance.SetTemporaryFXVolume(value);
    }

    private void SetControllersToDefaultValues()
    {
        Debug.Log("SetControllersToDefaultValues");
        SetControllersByOptionsSet(OptionsManager.Instance.GetDefaultOtionsSet());
    }

    private void SetControllersToActiveValues()
    {
        {
            Debug.Log("SetControllersToActiveValues");
            SetControllersByOptionsSet(OptionsManager.Instance.GetActiveOtionsSet());
        }
    }

    public void SetControllersByOptionsSet(OptionsSet_SO settings)
    {
        masterVolumeSlider.value = settings.masterVolume;
        musicVolumeSlider.value = settings.musicVolume;
        soundFXVolumeSlider.value = settings.soundFXVolume;
    }
}
