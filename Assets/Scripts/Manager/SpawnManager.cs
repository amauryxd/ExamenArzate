using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    public static event Action<int> roundSend;
    public static event Action finishGame;
    [SerializeField] private WaveData dataToSpawn;
    [SerializeField] private Vector3 minRange;
    [SerializeField] private Vector3 maxRange;
    private bool canGameTryToWin;

    private int round;
    private int enemyCuanity;
    private bool canSpawnEnemies;

    void OnEnable()
    {
        QueryManager.textSend += WaveDataAssigner;
        GameManager.StartGame += SetGame;
    }
    void OnDisable()
    {
        QueryManager.textSend -= WaveDataAssigner;
        GameManager.StartGame -= SetGame;
    }
    void Start()
    {
        round = 0;
        canGameTryToWin = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RoundStart()
    {
        if (round < dataToSpawn.Waves.Length)
        {
            WaveSpawn(round);
            roundSend?.Invoke(round);
        }
        else if(canGameTryToWin)
        {
            finishGame?.Invoke();
        }
    }

    public void WaveSpawn(int round)
    {

        for (int indexWaveSpawn = 0; indexWaveSpawn < dataToSpawn.Waves[round].Enemies.Length; indexWaveSpawn++)
        {
            StartCoroutine(EnemyToSpawn(dataToSpawn.Waves[round].Enemies[indexWaveSpawn].Enemy, dataToSpawn.Waves[round].Enemies[indexWaveSpawn].Time));
            //Debug.Log("Ronda " + round+1 + ", Enemigo " + indexWaveSpawn + " spawneado, era del tipo: "+dataToSpawn.Waves[round].Enemies[indexWaveSpawn].Enemy);
        }
    }

    public IEnumerator EnemyToSpawn(int type, float timeToWait)
    {
        GameObject enemy = PoolManager.Instance.RequestEnemy(type);
        GameManager.enemiesLeft.Add(enemy);
        yield return new WaitForSeconds(timeToWait);
        enemy.transform.position = SpawnPointEnemy();
        enemy.GetComponent<NavMeshAgent>().enabled = true;
        enemy.GetComponent<EnemyBehaviour>().canAssignBehaviour = true;
        enemy.GetComponent<EnemyBehaviour>().canStartBehaviour = true;
    }
    public Vector3 SpawnPointEnemy() {
        return new Vector3(UnityEngine.Random.Range(minRange.x,maxRange.x),UnityEngine.Random.Range(minRange.y,maxRange.y),UnityEngine.Random.Range(minRange.z,maxRange.z));
    }
    public void WaveDataAssigner(WaveData data)
    {
        dataToSpawn = data;
    }
    public void SetGame()
    {
        RoundStart();
        canGameTryToWin = true;
        round++;
    }
}
