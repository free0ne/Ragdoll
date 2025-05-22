using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Color brokenColor;

    public void Init(Color brokenColor)
    {
        this.brokenColor = brokenColor;
    }
    
    public void OnRagdollBroken()
    {
        spriteRenderer.color = brokenColor;
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
