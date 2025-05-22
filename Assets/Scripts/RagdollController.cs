using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [Header("Motors")] 
    [SerializeField] private Motor rootBoneMotor;
    [SerializeField] private Motor upperTorsoMotor;
    [SerializeField] private Motor headMotor;

    [SerializeField] private List<Motor> legMotors;
    [SerializeField] private List<Motor> shoulderMotors;

    [Header("Torque forces")] 
    [SerializeField] private float rootBoneForce;

    [SerializeField] private float upperTorsoForce;
    [SerializeField] private float headForce;

    [SerializeField] private float legForce;
    [SerializeField] private float shoulderForce;

    [Header("Ragdoll mode")] 
    [SerializeField] private float delayBeforeStartingRecovery = 1f;

    [SerializeField] private float recoveryTime = 1f;
    [SerializeField] private float relaxMultiplier;
    [SerializeField] private List<SelectableBone> bones;

    [Header("Spring to target")] 
    [SerializeField] private float springDistance;

    [SerializeField] private float springDampingRatio;
    [SerializeField] private float springFrequency;

    [Header("Joints")]
    [SerializeField] private List<HingeJoint2D> joints;
    [SerializeField] private List<JointBreakChecker> jointBreakCheckers;
    [SerializeField] private float breakForce;
    
    [Header("Coloring")]
    [SerializeField] private RagdollAppearanceController ragdollAppearanceController;

    private bool isRagdoll;
    private bool isBroken;
    private Coroutine toStrongBodyCoroutine;
    
    public RagdollAppearanceController RagdollAppearanceController => ragdollAppearanceController;
    
    private void Awake()
    {
        SetForces(1);
        
        foreach (var bone in bones)
            bone.Init(this);

        foreach (var joint in joints)
        {
            joint.breakForce = breakForce;
        }

        foreach (var jointBreakChecker in jointBreakCheckers)
        {
            jointBreakChecker.Init(this);
        }
    }

    private void SetForces(float forceMultiplier)
    {
        rootBoneMotor.SetForce(rootBoneForce * forceMultiplier);
        upperTorsoMotor.SetForce(upperTorsoForce * forceMultiplier);
        headMotor.SetForce(headForce * forceMultiplier);

        foreach (var motor in legMotors)
            motor.SetForce(legForce * forceMultiplier);
        
        foreach (var motor in shoulderMotors)
            motor.SetForce(shoulderForce * forceMultiplier);
    }
    
    public void SwitchToRagdoll()
    {
        if (toStrongBodyCoroutine != null)
        {
            StopCoroutine(toStrongBodyCoroutine);
            toStrongBodyCoroutine = null;
        }
        
        isRagdoll = true;
        SetForces(relaxMultiplier);
    }
    
    public void SwitchToStrongBodyAfterDelay()
    {
        if (isBroken)
            return;
        
        if (toStrongBodyCoroutine != null)
        {
            StopCoroutine(toStrongBodyCoroutine);
            toStrongBodyCoroutine = null;
        }

        toStrongBodyCoroutine = StartCoroutine(Recovering());
    }

    public void OnJointBroken()
    {
        isBroken = true;
        SwitchToRagdoll();

        ragdollAppearanceController.OnJointBroken();
    }
    
    private IEnumerator Recovering()
    {
        yield return new WaitForSeconds(delayBeforeStartingRecovery);
        
        float startMultiplier = relaxMultiplier;
        float elapsed = 0f;

        while (elapsed < recoveryTime)
        {
            elapsed += Time.deltaTime;
            float strengthMultiplier = Mathf.Lerp(startMultiplier, 1, elapsed / recoveryTime);
            SetForces(strengthMultiplier);

            yield return null;
        }

        SetForces(1);
    }

    public float GetTargetSpringDistance()
    {
        return springDistance;
    }

    public float GetTargetSpringDamping()
    {
        return springDampingRatio;
    }
    
    public float GetTargetSpringFrequency()
    {
        return springFrequency;
    }
}
