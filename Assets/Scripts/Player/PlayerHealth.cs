using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int plyLife;
    public static event Action plyGetHit;
    public static event Action plyDied;
    private int actualLife;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actualLife = plyLife;
    }

    public void GetHitPly()
    {
        actualLife--;
        plyGetHit?.Invoke();
        if (actualLife <= 0)
        {
            plyDied?.Invoke();
        }
    }
}
