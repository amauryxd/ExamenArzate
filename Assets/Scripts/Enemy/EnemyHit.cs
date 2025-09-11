using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth plyRef))
            {
                plyRef.GetHitPly();
            }
        }
    }
}
