using System;
using UnityEngine;

public class CustomizationController : MonoBehaviour
{
    [SerializeField] private GameObject customizationPanel;
    [SerializeField] private PreviewController previewController;
    
    [SerializeField] private Color defaultColor;
    [SerializeField] private Sprite defaultEyes;
    [SerializeField] private Sprite defaultMouth;
    
    [SerializeField] private GameObject colorTab;
    [SerializeField] private GameObject eyesTab;
    [SerializeField] private GameObject mouthTab;
    [SerializeField] private GameObject earsTab;
    [SerializeField] private GameObject hornsTab;
    
    [SerializeField] private SelectableRaycaster raycaster;
    
    public static CustomizationController Instance { get; private set; }
    
    public PlayerAppearance Appearance { get; private set; }

    private const string PLAYER_APPEARANCE_KEY = "PlayerAppearance";
    
    private void Awake()
    {
        Instance = this;
        LoadAppearance();
        ApplyAppearance();
    }

    public void ShowCustomizationPanel()
    {
        raycaster.enabled = false;
        
        customizationPanel.SetActive(true);
        previewController.SetCurrentAppearance();
    }

    public void HideCustomizationPanel()
    {
        SaveAppearance();
        ApplyAppearance();
        customizationPanel.SetActive(false);
        
        raycaster.enabled = true;
    }

    private void ApplyAppearance()
    {
        GameManager.Instance?.CurrentRagdoll?.RagdollAppearanceController.SetAppearance(Appearance);
    }

    private void SaveAppearance()
    {
        Appearance.BeforeSave();
        string json = JsonUtility.ToJson(Appearance);
        PlayerPrefs.SetString(PLAYER_APPEARANCE_KEY, json);
        PlayerPrefs.Save();
    }

    private void LoadAppearance()
    {
        if (PlayerPrefs.HasKey(PLAYER_APPEARANCE_KEY))
        {
            try
            {
                string json = PlayerPrefs.GetString(PLAYER_APPEARANCE_KEY);
                Appearance = JsonUtility.FromJson<PlayerAppearance>(json);
                Appearance.AfterLoad();
            }
            catch (Exception)
            {
                Debug.LogError("Failed to deserialize appearance");
                SetDefaultAppearance();
            }
        }
        else
        {
            SetDefaultAppearance();
        }
    }

    private void SetDefaultAppearance()
    {
        Appearance = new PlayerAppearance(
            defaultColor, 
            defaultEyes, 
            defaultMouth, 
            new EarsData(null, 0), 
            new HornData(null, 0, false));
    }

    #region Tabs

    public void OnColorTabChosen()
    {
        CloseAllTabsBut(colorTab);
    }
    
    public void OnEyesTabChosen()
    {
        CloseAllTabsBut(eyesTab);
    }
    
    public void OnMouthTabChosen()
    {
        CloseAllTabsBut(mouthTab);
    }

    public void OnEarsTabChosen()
    {
        CloseAllTabsBut(earsTab);
    }
    
    public void OnHornsTabChosen()
    {
        CloseAllTabsBut(hornsTab);
    }

    private void CloseAllTabsBut(GameObject tab)
    {
        colorTab.SetActive(colorTab == tab);
        eyesTab.SetActive(eyesTab == tab);
        mouthTab.SetActive(mouthTab == tab);
        earsTab.SetActive(earsTab == tab);
        hornsTab.SetActive(hornsTab == tab);
    }

    #endregion
}
