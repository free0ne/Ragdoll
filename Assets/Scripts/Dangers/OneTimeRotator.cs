using System;
using UnityEngine;

public class OneTimeRotator : MonoBehaviour
{
    [SerializeField] private Transform transformToRotate;
    
    [SerializeField] private float speed;
    [SerializeField] private float targetAngle;
    
    private void Update()
    {
        var diff = transformToRotate.localRotation.eulerAngles.z - targetAngle;
        diff %= 360;
        
        if (Math.Abs(diff) > 0.5f)
        {
            transformToRotate.Rotate(0f, 0f, speed * Time.deltaTime);
        }
    }
}
