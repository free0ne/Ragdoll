using UnityEngine;

public class JointBreakChecker : MonoBehaviour
{
    private RagdollController ragdollController;

    public void Init(RagdollController ragdollController)
    {
        this.ragdollController = ragdollController;
    }
    
    private void OnJointBreak2D(Joint2D brokenJoint)
    {
        ragdollController.OnJointBroken();
    }
}
