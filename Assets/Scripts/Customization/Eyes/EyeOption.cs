public class EyeOption : CustomizationOptionRealization
{
    public override void OnOptionClicked(OptionData data)
    {
        PreviewController.Instance.OnEyesChosen(data.Image.sprite);
    }
}
