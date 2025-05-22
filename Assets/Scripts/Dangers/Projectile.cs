using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private const float LIFE_TIME = 2f;
    private Coroutine destroyCoroutine;
    
    public void AddForceOnSpawn(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
        destroyCoroutine = StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(LIFE_TIME);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (destroyCoroutine != null)
            StopCoroutine(destroyCoroutine);
    }
}
