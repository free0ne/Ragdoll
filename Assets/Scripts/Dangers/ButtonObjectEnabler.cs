using System.Collections.Generic;
using UnityEngine;

public class ButtonObjectEnabler : ButtonActor
{
    [SerializeField] private List<GameObject> objectsToEnable;

    public override void ButtonPressed()
    {
        foreach (var obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }
}
