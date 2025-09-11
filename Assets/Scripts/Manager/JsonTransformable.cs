using UnityEngine;

public class JsonTransformable : MonoBehaviour
{
    public WavesStructure wavesStructure;
    void OnEnable()
    {
        QueryManager.textSend += FromJsonToStructure;
    }
    void OnDisable()
    {
        QueryManager.textSend -= FromJsonToStructure;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FromJsonToStructure(string json)
    {
        Debug.Log(json);
        wavesStructure = JsonUtility.FromJson<WavesStructure>(json);
        Debug.Log(wavesStructure);
    }
}
