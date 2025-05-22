using UnityEngine;

public abstract class ButtonActor : MonoBehaviour
{
    public abstract void ButtonPressed();
    public virtual void ButtonReleased() { }
}
