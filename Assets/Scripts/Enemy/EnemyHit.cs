using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Pasa el collision compare tag");
            if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth plyRef))
            {
                Debug.Log("pasa el collision try get component");
                plyRef.GetHitPly();
            }
        }
    }
}
