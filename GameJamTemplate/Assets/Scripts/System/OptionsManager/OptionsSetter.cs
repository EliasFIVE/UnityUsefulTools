using UnityEngine;

public class OptionsSetter : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private OptionsSet_SO defaultOptionsSet;

    [Header("Set Dynamicaly")]
    [SerializeField] private OptionsSet_SO activeOptionsSet;

    public OptionsSet_SO DefaultOptionsSet
    {
        get { return defaultOptionsSet; }
    }
    public OptionsSet_SO ActiveOptionsSet
    {
        get { return activeOptionsSet; }
    }

    private void Awake()
    {
        if (defaultOptionsSet != null)
            activeOptionsSet = Instantiate(defaultOptionsSet);
    }

    public void ChangeActiveOptionsSetValues(OptionsSet_SO optionsSet)
    {
         activeOptionsSet.ReplaceAllValues(optionsSet);
    }
}
