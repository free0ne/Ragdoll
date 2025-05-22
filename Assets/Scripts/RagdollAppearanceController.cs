using System.Collections.Generic;
using UnityEngine;

public class RagdollAppearanceController : MonoBehaviour
{
    [SerializeField] private List<ColorController> colorControllers;
    [SerializeField] private Color brokenColor;

    [SerializeField] private SpriteRenderer eyes;
    [SerializeField] private SpriteRenderer mouth;
    [SerializeField] private SpriteRenderer ears;
    [SerializeField] private SpriteRenderer horns;

    private void Awake()
    {
        foreach (var colorController in colorControllers)
        {
            colorController.Init(brokenColor);
        }
    }
    
    public void OnJointBroken()
    {
        foreach (var colorController in colorControllers)
        {
            colorController.OnRagdollBroken();
        }

        if (CustomizationController.Instance.Appearance.EarsData.Sprite != null)
            ears.color = brokenColor;
        
        if (CustomizationController.Instance.Appearance.HornData.Sprite != null && CustomizationController.Instance.Appearance.HornData.ApplyBodyColor)
            horns.color = brokenColor;
    }

    public void SetAppearance(PlayerAppearance appearance)
    {
        foreach (var colorController in colorControllers)
        {
            colorController.SetColor(appearance.BodyColor);
        }
        
        eyes.sprite = appearance.Eyes;
        mouth.sprite = appearance.Mouth;
        
        if (appearance.EarsData.Sprite != null)
        {
            ears.sprite = appearance.EarsData.Sprite;
            ears.color = appearance.BodyColor;
            
            var vector3 = ears.transform.localPosition;
            vector3.y = appearance.EarsData.PlayerHeight;
            ears.transform.localPosition = vector3;
        }
        else
        {
            ears.sprite = null;
        }
        
        if (appearance.HornData.Sprite != null)
        {
            horns.sprite = appearance.HornData.Sprite;
            
            if (appearance.HornData.ApplyBodyColor)
                horns.color = appearance.BodyColor;
            else
                horns.color = Color.white;
            
            var vector3 = horns.transform.localPosition;
            vector3.y = appearance.HornData.PlayerHeight;
            horns.transform.localPosition = vector3;
        }
        else
        {
            horns.sprite = null;
        }
    }
}
