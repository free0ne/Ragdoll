using UnityEngine;

public class ExplosiveBarrel : Usable
{
    [SerializeField] private float fieldOfEffect;
    [SerializeField] private float force;
    
    [SerializeField] private LayerMask affectedLayers;

    [SerializeField] private GameObject explosionEffectPrefab;

    private void Explode()
    {
        var objects = Physics2D.OverlapCircleAll(transform.position, fieldOfEffect, affectedLayers);

        foreach (var obj in objects)
        {
            var movementVector = obj.transform.position - transform.position;
            if (obj.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb.AddForce(movementVector * force, ForceMode2D.Impulse);
            }
        }
        
        var explosionEffectInstance = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        Destroy(explosionEffectInstance, 10);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfEffect);
    }

    public override void Use()
    {
        Explode();
    }
}
