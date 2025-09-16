using System;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    public float cooldown = 3f;
    public int bulletCount = 4;
    
    public float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            Debug.Log("Shooting");
            ShootBullets();
            timer = 0f;
        }
    }

    private void ShootBullets()
    {
        float angleCounter = 360f / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = Mathf.Deg2Rad * angleCounter * i; //Deg -> Rad

            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);

            float rotation = Mathf.Atan2(y, x) * Mathf.Rad2Deg;//gives angle and Rad -> Deg

            GameObject firePoint = Instantiate(rocketPrefab, transform.position, Quaternion.Euler(0,0,rotation));
            firePoint.GetComponent<Bullet>().SetDirection(x, y); //class Bullet 
        }
    }
}
