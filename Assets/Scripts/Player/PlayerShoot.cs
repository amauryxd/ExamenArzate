using UnityEngine;

public class PlayerShoot : InputHandler
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bullet;

    void Update()
    {
        Shooting();
    }

    public void Shooting()
    {
        if (isShooting)
        {
            bullet = PoolManager.Instance.RequestBullet();
            bullet.transform.rotation = shootPoint.parent.rotation;
            bullet.transform.position = shootPoint.position;
            isShooting =false;  
        }
    }
}
