using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int[] EnemyLife;
    private int actualLife;
    
    private EnemyBehaviour enemyTypeReferene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void getHit()
    {
        actualLife--;
        if (actualLife <= 0)
        {
            IsDead();
        }
    }
    public void IsDead()
    {
        gameObject.SetActive(false);
    }
    void OnEnable()
    {
        enemyTypeReferene = GetComponent<EnemyBehaviour>();
        actualLife = EnemyLife[enemyTypeReferene.typeEnemy];
    }
    // Update is called once per frame
    void OnDisable()
    {
        GameManager.enemiesLeft.Remove(gameObject);
        GetComponent<NavMeshAgent>().enabled = false;
        if(enemyTypeReferene != null)
        enemyTypeReferene.canStartBehaviour = false;
    }
}
