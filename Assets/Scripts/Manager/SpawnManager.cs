using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private WaveData dataToSpawn;
    [SerializeField] private Vector3 minRange;
    [SerializeField] private Vector3 maxRange;

    void OnEnable()
    {
        QueryManager.textSend += WaveDataAssigner;
    }
    void OnDisable()
    {
        QueryManager.textSend -= WaveDataAssigner;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WaveDataAssigner(WaveData data)
    {
        dataToSpawn = data;
    }
}
