using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public float cooldown = 2f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
    }

    public void TryShoot(Transform enemy)
    {
        if (timer < cooldown || enemy == null) return;

        Vector2 direction = enemy.position - transform.position;
        float distance = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);

        if (distance == 0f) return;

        float normalizeX = direction.x / distance;
        float normalizeY = direction.y / distance;

        float rotation = Mathf.Atan2(normalizeY, normalizeX) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, rotation));
        bullet.GetComponent<Bullet>().SetDirection(normalizeX, normalizeY, enemy);

        timer = 0f;
    }
}
