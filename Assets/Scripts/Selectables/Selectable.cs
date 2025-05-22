using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Rigidbody2D manualRigidbody;
    [SerializeField] private Collider2D manualCollider;
    [SerializeField] protected Joint2D joint;
    
    protected Rigidbody2D rootBody;
    
    private float springDistance;
    private float dampingRatio = 0.2f;
    private float frequency = 1;
    
    private SpringJoint2D jointToTarget;

    private void Awake()
    {
        if (manualRigidbody == null)
            rootBody = GetComponent<Rigidbody2D>();
        else
            rootBody = manualRigidbody;
    }

    public Transform GetTransform()
    {
        if (!manualCollider)
            return transform;
        else
            return manualCollider.transform;
    }
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        // Этот код сработает при клике по объекту с этим скриптом
        Debug.Log("Объект был кликнут: " + gameObject.name);
    }
    
    public virtual void OnSelected(Rigidbody2D target)
    {
        CreateSpringJoint(target);
    }

    public virtual void OnDeselected()
    {
        DestroyJointToTarget();
    }

    private void CreateSpringJoint(Rigidbody2D target)
    {
        jointToTarget = rootBody.AddComponent<SpringJoint2D>();
        
        jointToTarget.connectedBody = target;
        jointToTarget.autoConfigureDistance = false;
        jointToTarget.autoConfigureConnectedAnchor = false;
        
        if (manualCollider)
            jointToTarget.anchor = rootBody.transform.InverseTransformPoint(manualCollider.transform.position);
        
        jointToTarget.distance = GetSpringDistance();
        jointToTarget.dampingRatio = GetDampingRatio();
        jointToTarget.frequency = GetSpringFrequency();
    }

    protected virtual float GetSpringDistance()
    {
        return springDistance;
    }

    protected virtual float GetDampingRatio()
    {
        return dampingRatio;
    }
    
    protected virtual float GetSpringFrequency()
    {
        return frequency;
    }

    private void DestroyJointToTarget()
    {
        Destroy(jointToTarget);
    }
}
