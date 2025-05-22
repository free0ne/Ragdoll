using System;
using UnityEngine;

public class HornOption : CustomizationOptionRealization
{
    public override void OnOptionClicked(OptionData data)
    {
        if (data.Image.sprite.name == "UISprite")
            PreviewController.Instance.OnHornsChosen(new HornData(null, data.PlayerHeight, data.ApplyBodyColor));
        else
            PreviewController.Instance.OnHornsChosen(new HornData(data.Image.sprite, data.PlayerHeight, data.ApplyBodyColor));
    }
}

[Serializable]
public class HornData
{
    public Sprite Sprite;
    public float PlayerHeight;
    public bool ApplyBodyColor;

    public HornData(Sprite sprite, float playerHeight, bool applyBodyColor)
    {
        Sprite = sprite;
        PlayerHeight = playerHeight;
        ApplyBodyColor = applyBodyColor;
    }
}
