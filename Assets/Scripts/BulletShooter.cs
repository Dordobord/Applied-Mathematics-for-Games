using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    public float cooldown = 2f; 
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
    }

    public void TryShoot(Vector2 direction)
    {
        if (timer < cooldown) return; 

        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(rocketPrefab, transform.position, Quaternion.Euler(0, 0, rotation));
        bullet.GetComponent<Bullet>().SetDirection(direction.x, direction.y);

        timer = 0f; 
    }
}
