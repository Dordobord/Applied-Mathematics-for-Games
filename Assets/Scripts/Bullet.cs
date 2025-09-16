using UnityEngine;

public class Bullet : MonoBehaviour
{
    float x1, y1;
    public float speed = 5f;

    public void SetDirection(float dx, float dy)
    {
        x1 = dx;
        y1 = dy;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += x1 * speed * Time.deltaTime;
        pos.y += y1 * speed * Time.deltaTime;
        transform.position = pos;
    }
}
