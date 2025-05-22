using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewController : MonoBehaviour
{
    [SerializeField] private RagdollAppearanceController ragdollAppearanceController;
    
    public static PreviewController Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    public void SetCurrentAppearance()
    {
        ragdollAppearanceController.SetAppearance(CustomizationController.Instance.Appearance);
    }

    #region Eyes

    public void OnEyesChosen(Sprite chosenEyes)
    {
        CustomizationController.Instance.Appearance.Eyes = chosenEyes;
        ragdollAppearanceController.SetAppearance(CustomizationController.Instance.Appearance);
    }

    #endregion

    #region Mouth

    public void OnMouthChosen(Sprite chosenMouth)
    {
        CustomizationController.Instance.Appearance.Mouth = chosenMouth;
        ragdollAppearanceController.SetAppearance(CustomizationController.Instance.Appearance);
    }

    #endregion
    
    #region Ears

    public void OnEarsChosen(EarsData earsData)
    {
        CustomizationController.Instance.Appearance.EarsData = earsData;
        ragdollAppearanceController.SetAppearance(CustomizationController.Instance.Appearance);
    }

    #endregion
    
    #region Horns

    public void OnHornsChosen(HornData hornData)
    {
        CustomizationController.Instance.Appearance.HornData = hornData;
        ragdollAppearanceController.SetAppearance(CustomizationController.Instance.Appearance);
    }

    #endregion
    
    #region Color
    
    public void OnColorChosen(Color chosenColor)
    {
        CustomizationController.Instance.Appearance.BodyColor = chosenColor;
        ragdollAppearanceController.SetAppearance(CustomizationController.Instance.Appearance);
    }
    
    #endregion
}
