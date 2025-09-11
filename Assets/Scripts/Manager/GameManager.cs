using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action StartGame;
    public static List<GameObject> enemiesLeft = new List<GameObject>();
    public bool canStart;
    public Canvas canvasWin;
    public Canvas canvasGameplay;
    public Canvas canvasLose;
    public GameObject plyReference;
    void OnEnable()
    {
        SpawnManager.finishGame += WinCondition;
        PlayerHealth.plyDied += LoseCondition;
    }
    void OnDisable()
    {
        SpawnManager.finishGame -= WinCondition;
        PlayerHealth.plyDied -= LoseCondition;
        enemiesLeft.Clear();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        canStart = false;
    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        StartGame?.Invoke();
        canStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesLeft.Count <= 0 && canStart)
        {
            StartGame?.Invoke();
        }
    }
    public void WinCondition()
    {
        canvasGameplay.enabled = false;
        canvasWin.enabled = true;
    }
    public void LoseCondition()
    {
        plyReference.SetActive(true);
        canvasGameplay.enabled = false;
        canvasLose.enabled = true;
    }
    
}
