using System.Collections.Generic;
using UnityEngine;

public class ButtonChecker : MonoBehaviour
{
    [SerializeField] private float posYThreshold;
    [SerializeField] private List<ButtonActor> actors;
    
    private bool isPressed = false;

    private void Update()
    {
        if (!isPressed && transform.localPosition.y <= posYThreshold)
        {
            isPressed = true;
            OnPressed();
        }
        else if (isPressed && transform.localPosition.y > posYThreshold)
        {
            isPressed = false;
            OnReleased();
        }
    }

    private void OnPressed()
    {
        foreach (var actor in actors)
        {
            actor.ButtonPressed();
        }
    }
    
    private void OnReleased()
    {
        foreach (var actor in actors)
        {
            actor.ButtonReleased();
        }
    }
}
