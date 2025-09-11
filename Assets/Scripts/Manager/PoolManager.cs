using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField] private Transform plyPos;
    [Header("Pool Bullets")]
    [SerializeField] private int bulletPoolSize;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<GameObject> bulletsPool;

    [Header("Pool Enemys")]
    [SerializeField] private int enemysPoolSize;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<GameObject> enemysPool;


    private static PoolManager instance;
    public static PoolManager Instance { get { return instance; } }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        AddToListPrefabs(bulletPrefab, bulletPoolSize, bulletsPool);
        AddToEnemyList();
    }
    void Update()
    {

    }
    public void AddToListPrefabs(GameObject prefabToAdd, int amount, List<GameObject> listToModify)
    {
        for (int indexLists = 0; indexLists < amount; indexLists++)
        {
            GameObject prefab = Instantiate(prefabToAdd);
            prefab.SetActive(false);
            listToModify.Add(prefab);
            prefab.transform.parent = transform;
        }
    }
    public void AddToEnemyList()
    {

            for (int indexEnemy = 0; indexEnemy < enemysPoolSize; indexEnemy++)
            {
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.SetActive(false);
                enemysPool.Add(enemy);
                enemy.transform.parent = transform;
            }

    }

    public GameObject RequestBullet()
    {
        for (int indexRequestBullet = 0; indexRequestBullet < bulletsPool.Count; indexRequestBullet++)
        {
            if (!bulletsPool[indexRequestBullet].activeSelf)
            {
                bulletsPool[indexRequestBullet].SetActive(true);
                return bulletsPool[indexRequestBullet];
            }
        }
        return null;
    }

    public GameObject RequestEnemy(int type)
    {
        for (int indexRequestEnemy = 0; indexRequestEnemy < enemysPool.Count; indexRequestEnemy++)
        {
            if (!enemysPool[indexRequestEnemy].activeSelf)
            {
                enemysPool[indexRequestEnemy].GetComponent<EnemyBehaviour>().playerPos = plyPos;
                enemysPool[indexRequestEnemy].GetComponent<EnemyBehaviour>().typeEnemy = type;
                enemysPool[indexRequestEnemy].transform.position = new Vector3(300, 1, 0);
                enemysPool[indexRequestEnemy].SetActive(true);
                return enemysPool[indexRequestEnemy];
            }
        }
        return null;
    }
}
