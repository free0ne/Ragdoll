using UnityEngine;

public class TargetPointer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public Rigidbody2D GetRigidbody()
    {
        return rb;
    }
}
