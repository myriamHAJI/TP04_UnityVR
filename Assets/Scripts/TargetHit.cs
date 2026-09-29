using UnityEngine;

public class TargetHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("CIBLE TOUCHEE");

            Destroy(collision.gameObject);
        }
    }
}