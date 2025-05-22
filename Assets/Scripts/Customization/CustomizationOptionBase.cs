using UnityEngine;
using UnityEngine.UI;

public class CustomizationOptionBase : MonoBehaviour
{
    [SerializeField] private CustomizationOptionRealization realization;
    
    [SerializeField] private Image image;
    [SerializeField] private float playerHeight;
    [SerializeField] private bool applyBodyColor;

    public void OnOptionClicked()
    {
        var data = new OptionData(image, playerHeight, applyBodyColor);
        realization.OnOptionClicked(data);
    }
}
