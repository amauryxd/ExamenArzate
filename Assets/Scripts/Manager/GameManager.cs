using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action StartGame;
    public static List<GameObject> enemiesLeft = new List<GameObject>();
    public List<GameObject> temp;
    public bool canStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        canStart = false;
    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        StartGame?.Invoke();
        canStart=true;
    }

    // Update is called once per frame
    void Update()
    {
        temp = enemiesLeft;
        if (enemiesLeft.Count <= 0 && canStart)
        {
            StartGame?.Invoke();
        }
    }
}
