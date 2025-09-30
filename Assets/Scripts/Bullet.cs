using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private float dx, dy;
    public float speed = 5f;
    public float lifeTime = 5f;       
    public float hitDistance = 0.5f;  
    private Transform player;

    public void SetDirection(float x, float y)
    {
        dx = x;
        dy = y;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, lifeTime); 
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += dx * speed * Time.deltaTime;
        pos.y += dy * speed * Time.deltaTime;
        transform.position = pos;

        if (player != null)
        {
            float dist = Vector3.Distance(transform.position, player.position);
            if (dist < hitDistance)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
