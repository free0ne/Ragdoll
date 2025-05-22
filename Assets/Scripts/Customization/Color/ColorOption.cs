public class ColorOption : CustomizationOptionRealization
{
    public override void OnOptionClicked(OptionData data)
    {
        PreviewController.Instance.OnColorChosen(data.Image.color);
    }
}
