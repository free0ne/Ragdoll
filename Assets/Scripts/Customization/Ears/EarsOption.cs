using System;
using UnityEngine;

public class EarsOption : CustomizationOptionRealization
{
    public override void OnOptionClicked(OptionData data)
    {
        if (data.Image.sprite.name == "UISprite")
            PreviewController.Instance.OnEarsChosen(new EarsData(null, data.PlayerHeight));
        else
            PreviewController.Instance.OnEarsChosen(new EarsData(data.Image.sprite, data.PlayerHeight));
    }
}

[Serializable]
public class EarsData
{
    public Sprite Sprite;
    public float PlayerHeight;

    public EarsData(Sprite sprite, float playerHeight)
    {
        Sprite = sprite;
        PlayerHeight = playerHeight;
    }
}
