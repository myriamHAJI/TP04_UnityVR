using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public ParticleSystem hitParticles;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("CIBLE TOUCHEE");

            if (hitParticles != null)
            {
                hitParticles.Play();
            }

            Destroy(collision.gameObject);
        }
    }
}