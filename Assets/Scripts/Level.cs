using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private RagdollController ragdollController;
    
    public int GetID() => id;
    public RagdollController GetRagdollController() => ragdollController;
}
