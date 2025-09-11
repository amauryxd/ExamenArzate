using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform plyPos;
    public float speedToFollow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetCloseTo();
    }

    public void GetCloseTo()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, plyPos.position.x, Time.deltaTime * speedToFollow), transform.position.y, Mathf.Lerp(transform.position.z, plyPos.position.z, Time.deltaTime * speedToFollow));
    }
}
