using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public ParticleSystem hitParticles;

    private bool hasBeenHit = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasBeenHit || !collision.gameObject.CompareTag("Bullet"))
            return;

        hasBeenHit = true;

        Destroy(collision.gameObject);

        if (hitParticles != null)
        {
            hitParticles.Play();
        }

        Renderer targetRenderer = GetComponent<Renderer>();
        if (targetRenderer != null)
        {
            targetRenderer.enabled = false;
        }

        Collider targetCollider = GetComponent<Collider>();
        if (targetCollider != null)
        {
            targetCollider.enabled = false;
        }

        Destroy(gameObject, 0.8f);
    }
}