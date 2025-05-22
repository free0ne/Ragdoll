using UnityEngine;

public class SelectableBone : Selectable
{
    private RagdollController parentRagdoll;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Spike>(out var spike))
        {
            Vector2 dir = (rootBody.transform.position - spike.transform.position).normalized;
            float power = 300f;
            rootBody.AddForceAtPosition(dir * power, collision.contacts[0].point, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.TryGetComponent<CircularSaw>(out var circularSaw))
        {
            Vector2 dir = (rootBody.transform.position - circularSaw.transform.position).normalized;
            float power = 300f;
            rootBody.AddForceAtPosition(dir * power, collision.contacts[0].point, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.TryGetComponent<SilentJointBreaker>(out var jointBreaker))
        {
            if (joint)
            {
                joint.breakForce = 0;
            }
        }
        else if (collision.gameObject.TryGetComponent<Usable>(out var usable))
        {
            usable.Use();
        }
    }

    // [SerializeField] private MeshRenderer meshRenderer;
    // [SerializeField] private Material selectedMaterial;
    // private Material notSelectedMaterial;

    
    // private void Awake()
    // {
    //     notSelectedMaterial = meshRenderer.material;
    // }
    
    // private void SetMaterial(bool selected)
    // {
    //     meshRenderer.material = selected ? selectedMaterial : notSelectedMaterial;
    // }

    public void Init(RagdollController ragdoll)
    {
        parentRagdoll = ragdoll;
    }
    
    public override void OnSelected(Rigidbody2D target)
    {
        // SetMaterial(true);
        parentRagdoll.SwitchToRagdoll();
        
        base.OnSelected(target);
    }

    public override void OnDeselected()
    {
        base.OnDeselected();
        
        parentRagdoll.SwitchToStrongBodyAfterDelay();
        // SetMaterial(false);
    }
    
    protected override float GetSpringDistance()
    {
        return parentRagdoll.GetTargetSpringDistance();
    }

    protected override float GetDampingRatio()
    {
        return parentRagdoll.GetTargetSpringDamping();
    }
    
    protected override float GetSpringFrequency()
    {
        return parentRagdoll.GetTargetSpringFrequency();
    }
}
