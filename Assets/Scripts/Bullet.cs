using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private float hitDist = 0.5f;
    [SerializeField] private int damage = 1;

    private float directionX, directionY;
    private Transform target;
    private Health health;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += directionX * speed * Time.deltaTime;
        pos.y += directionY * speed * Time.deltaTime;
        transform.position = pos;

        if (target != null)
        {
            float directX = target.position.x - pos.x;
            float directY = target.position.y - pos.y;
            float distance = Mathf.Sqrt(directX * directX + directY * directY);

            if (distance < hitDist)
            {
                if (health != null)
                    health.TakeDamage();

                Destroy(gameObject);
            }
        }
    }
    public void SetDirection(float x, float y, Transform enemy)
    {
        directionX = x;
        directionY = y;
        target = enemy;

        if (target != null)
            health = target.GetComponent<Health>();
    }
}
