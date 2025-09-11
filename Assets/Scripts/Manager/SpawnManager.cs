using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private WaveData dataToSpawn;
    [SerializeField] private Vector3 minRange;
    [SerializeField] private Vector3 maxRange;

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
        }
    }

    public void WaveSpawn(int round)
    {

        for (int indexWaveSpawn = 0; indexWaveSpawn < dataToSpawn.Waves[round].Enemies.Length; indexWaveSpawn++)
        {
            StartCoroutine(EnemyToSpawn(dataToSpawn.Waves[round].Enemies[indexWaveSpawn].Enemy, dataToSpawn.Waves[round].Enemies[indexWaveSpawn].Time));
        }
    }

    public IEnumerator EnemyToSpawn(int type, float timeToWait)
    {
        GameObject enemy = PoolManager.Instance.RequestEnemy(type);
        GameManager.enemiesLeft.Add(enemy);
        yield return new WaitForSeconds(timeToWait);
        enemy.transform.position = SpawnPointEnemy();
        enemy.GetComponent<NavMeshAgent>().enabled = true;
        enemy.GetComponent<EnemyBehaviour>().canStartBehaviour = true;
    }
    public Vector3 SpawnPointEnemy() {
        return new Vector3(Random.Range(minRange.x,maxRange.x),Random.Range(minRange.y,maxRange.y),Random.Range(minRange.z,maxRange.z));
    }
    public void WaveDataAssigner(WaveData data)
    {
        dataToSpawn = data;
    }
    public void SetGame()
    {
        RoundStart();
        round++;
    }
}
