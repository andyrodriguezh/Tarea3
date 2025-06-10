using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 1f;
    public float range = 4f;
    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * range;
        transform.position = new Vector3(startX + offset, transform.position.y, transform.position.z);
    }
}