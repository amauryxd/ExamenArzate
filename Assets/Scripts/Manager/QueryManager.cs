using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class QueryManager : MonoBehaviour
{
    public static event Action<WaveData> textSend;
    public string endpoint;
    Coroutine textGetter;
    void Start()
    {
        GetEndpoint();
    }
    [ContextMenu("Get")]
    public void GetEndpoint()
    {
        textGetter = StartCoroutine(RoutineGetEndopoint(endpoint));
    }

    public IEnumerator RoutineGetEndopoint(string url)
    {
        WWWForm form = new WWWForm();
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();
        if (webRequest.result.Equals(UnityWebRequest.Result.Success))
        {
            //textSend?.Invoke(webRequest.downloadHandler.text);
            WaveData data = JsonUtility.FromJson<WaveData>(webRequest.downloadHandler.text);
            textSend?.Invoke(data);
        }
    }
}
