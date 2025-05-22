using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform targetPoint;
    
    [SerializeField] private Projectile projectile;
    [SerializeField] private float projectileForce;
    
    public void Shoot()
    {
        var createdProjectile = Instantiate(projectile, spawnPoint.position, projectile.transform.localRotation);
        var force = targetPoint.position - spawnPoint.position;
        force = force.normalized * projectileForce; 
        createdProjectile.AddForceOnSpawn(force);
    }
}
