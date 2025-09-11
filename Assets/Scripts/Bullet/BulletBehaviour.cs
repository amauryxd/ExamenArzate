using System.Collections;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    private Coroutine toDespawn;

    void Start()
    {
        toDespawn = StartCoroutine(WaitToDespawn());
    }
    void Update()
    {
        MoveForwardBullet();
    }
    public void MoveForwardBullet()
    {
        transform.position += transform.right * Time.deltaTime * bulletSpeed;
    }
    public IEnumerator WaitToDespawn()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
    void OnDisable()
    {
        if(!(toDespawn == null))
        StopCoroutine(toDespawn);
    }
}
