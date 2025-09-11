using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Material[] enemyMaterials;
    private MeshRenderer mesh;
    public Vector3[] sizeEnemys;
    public int typeEnemy;
    public float[] enemySpeed;
    public Transform playerPos;
    NavMeshAgent nav;


    [Header("Enemy 2 Variables")]
    
    [SerializeField] private float sumToSpeed;
    [Header("Enemy 3 Variables")]
    private bool canRotate;

    Coroutine corutineBeha;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        mesh = GetComponent<MeshRenderer>();
        BehaviourEnemy(typeEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        RotateEnemy();
    }
    public void BehaviourEnemy(int enemyType)
    {
        switch (enemyType)
        {
            case 1:
                nav.speed = enemySpeed[0];
                transform.localScale = sizeEnemys[0];
                mesh.material = enemyMaterials[0];
                //MoveToPlayer();
                break;
            case 2:
                nav.speed = enemySpeed[1];
                transform.localScale = sizeEnemys[1];
                mesh.material = enemyMaterials[1];
                //MoveToPlayer();
                corutineBeha = StartCoroutine(SecondBehaviour());
                break;
            case 3:
                nav.speed = enemySpeed[2];
                transform.localScale = sizeEnemys[2];
                mesh.material = enemyMaterials[2];
                //MoveToPlayer();
                corutineBeha = StartCoroutine(ThirdBehaviour());
                break;
            case 4:
                //MoveToPlayer();
                nav.speed = enemySpeed[3];
                transform.localScale = sizeEnemys[3];
                mesh.material = enemyMaterials[3];
                break;
            default:
                break;
        }
    }

    public void MoveToPlayer()
    {
        nav.SetDestination(playerPos.position);
    }

    public IEnumerator SecondBehaviour()
    {
        while (true)
        {
            float newSpeed = enemySpeed[1] + sumToSpeed;
            nav.speed = newSpeed;
            yield return new WaitForSeconds(3);
            nav.speed = nav.speed = enemySpeed[1];
            yield return new WaitForSeconds(3);
        }
    }
    public IEnumerator ThirdBehaviour()
    {
        while (true)
        {
            nav.isStopped = true;
            canRotate = true;
            yield return new WaitForSeconds(3);
            nav.isStopped = false;
            canRotate = false;
            //nav.SetDestination(playerPos.position);
            yield return new WaitForSeconds(5);
        }
    }
    public void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(0, 15, 0);
        }
    }
    void OnDisable()
    {
        if (!(corutineBeha == null))
        {
            StopCoroutine(corutineBeha);
        }
    }
}
