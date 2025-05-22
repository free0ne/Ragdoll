using UnityEngine;

public class Motor : MonoBehaviour
{
    [SerializeField] private bool useInitialRotation;
    [SerializeField] private float targetAngle;
    
    private float torqueForce = 100f;
    private Rigidbody2D rb;

    public void SetForce(float torqueForce)
    {
        this.torqueForce = torqueForce;
    }
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (useInitialRotation)
            targetAngle = transform.eulerAngles.z;
    }

    private void FixedUpdate()
    {
        float currentAngle = transform.eulerAngles.z;
        float error = Mathf.DeltaAngle(currentAngle, targetAngle);
        
        //float damping = 1f - Mathf.Clamp01(Mathf.Abs(error) / 90f);
        //float torque = error * torqueForce * Time.fixedDeltaTime * damping;
        
        float torque = error * torqueForce * Time.fixedDeltaTime;
        float dampingFactor = 0.75f; // Чем ближе к 1, тем дольше затухает
        rb.angularVelocity *= dampingFactor;
        
        rb.AddTorque(torque, ForceMode2D.Force);
    }
}
