using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("Pool Bullets")]
    [SerializeField] private int bulletPoolSize;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<GameObject> bulletsPool;

    [Header("Enemy Type 1 Pool")]
    [SerializeField] private int manyEnemys;
    [SerializeField] private int enemysPoolSize;
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private List<GameObject>[] enemysPool;


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
        for (int indexEnemyList = 0; indexEnemyList < manyEnemys; indexEnemyList++)
        {
            for (int indexEnemy = 0; indexEnemy < enemysPoolSize; indexEnemy++)
            {
                GameObject enemy = Instantiate(enemys[indexEnemyList]);
                enemy.SetActive(false);
                enemysPool[indexEnemyList].Add(enemy);
                enemy.transform.parent = transform;
            }
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
        for (int indexRequestEnemy = 0; indexRequestEnemy < enemysPool[type-1].Count; indexRequestEnemy++)
        {
            if (!enemysPool[type][indexRequestEnemy].activeSelf)
            {
                enemysPool[type][indexRequestEnemy].SetActive(true);
                return enemysPool[type][indexRequestEnemy];
            }
        }
        return null;
    }
}
