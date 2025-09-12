using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action StartGame;
    public static List<GameObject> enemiesLeft = new List<GameObject>();
    public bool canStart;
    public Canvas canvasWinLose;
    public Canvas canvasGameplay;
    public TextMeshProUGUI textToModify;
    public GameObject plyReference;
    void OnEnable()
    {
        SpawnManager.finishGame += WinCondition;
        PlayerHealth.plyDied += LoseCondition;
        QueryManager.textSend += DataGetToStart;
    }
    void OnDisable()
    {
        SpawnManager.finishGame -= WinCondition;
        PlayerHealth.plyDied -= LoseCondition;
        QueryManager.textSend -= DataGetToStart;
        enemiesLeft.Clear();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        canStart = false;
    }
    // private IEnumerator Start()
    // {
    //     yield return new WaitForSeconds(0.5f);
    //     StartGame?.Invoke();
    //     canStart = true;
    // }

    private void DataGetToStart(WaveData data)
    {
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
        plyReference.SetActive(false);
        canvasGameplay.enabled = false;
        canvasWinLose.enabled = true;
        textToModify.text = "¡Ganaste!";
        textToModify.color = Color.green;
    }
    public void LoseCondition()
    {
        plyReference.SetActive(false);
        canvasGameplay.enabled = false;
        canvasWinLose.enabled = true;
        textToModify.text = "¡Perdiste!";
        textToModify.color = Color.red;
    }
    
}
