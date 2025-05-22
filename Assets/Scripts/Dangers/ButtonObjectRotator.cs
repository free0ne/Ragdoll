using System;
using UnityEngine;

public class ButtonObjectRotator : ButtonActor
{
    [SerializeField] private Transform objectToRotate;
    
    [SerializeField] private float openedRotation;
    [SerializeField] private float closedRotation;

    [SerializeField] private float speed;
    [SerializeField] private bool openNonClockwise;

    private (bool opening, float rotation) target;
    private float openSpeed;

    private void Awake()
    {
        target = (false, closedRotation);
        openSpeed = openNonClockwise ? speed : -speed;
    }

    private void Update()
    {
        var diff = objectToRotate.localRotation.eulerAngles.z - target.rotation;
        var currentSpeed = target.opening ? openSpeed : -openSpeed;

        diff %= 360;
        
        if (Math.Abs(diff) > 0.5f)
        {
            objectToRotate.Rotate(0f, 0f, currentSpeed * Time.deltaTime); // вращение по оси Z
        }
    }

    public override void ButtonPressed()
    {
        target = (true, openedRotation);
    }
    
    public override void ButtonReleased()
    {
        target = (false, closedRotation);
    }
}
