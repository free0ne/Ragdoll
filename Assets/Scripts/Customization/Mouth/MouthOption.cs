public class MouthOption : CustomizationOptionRealization
{
    public override void OnOptionClicked(OptionData data)
    {
        PreviewController.Instance.OnMouthChosen(data.Image.sprite);
    }
}
