using System.Collections.Generic;
using UnityEngine;

public class ButtonObjectUser : ButtonActor
{
    [SerializeField] private List<Usable> usables;

    public override void ButtonPressed()
    {
        foreach (var usable in usables)
        {
            usable.Use();
        }
    }
}
