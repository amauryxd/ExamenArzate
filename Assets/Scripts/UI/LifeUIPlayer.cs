using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class LifeUIPlayer : MonoBehaviour
{
    public Image[] Lifes;
    private int count;
    void OnEnable()
    {
        PlayerHealth.plyGetHit += HandleHit;
    }
    void OnDisable()
    {
        PlayerHealth.plyGetHit -= HandleHit;
    }
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HandleHit()
    {
        Lifes[count].enabled = false;
        count++;
    }
}
