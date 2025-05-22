using System.Collections.Generic;
using UnityEngine;

public class ButtonObjectComponentDestroyer : ButtonActor
{
    [SerializeField] private List<GameObject> objectsToDestroy;
    [SerializeField] private List<Joint2D> jointsToDestroy;
    
    public override void ButtonPressed()
    {
        foreach (var go in objectsToDestroy)
        {
            Destroy(go);
        }
        
        foreach (var joint in jointsToDestroy)
        {
            Destroy(joint);
        }
    }
}
