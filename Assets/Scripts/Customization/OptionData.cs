using UnityEngine.UI;

public class OptionData
{
    public Image Image;
    public float PlayerHeight;
    public bool ApplyBodyColor;
    
    public OptionData(Image image, float playerHeight, bool applyBodyColor)
    {
        Image = image;
        PlayerHeight = playerHeight;
        ApplyBodyColor = applyBodyColor;
    }
}
