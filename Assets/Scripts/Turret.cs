using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;      
    public float rotationSpeed = 5f; 
    public float fireRange = 8f;     
    public float fireAngle = 10f; 

    private BulletShooter shooter;

    void Start()
    {
        shooter = GetComponent<BulletShooter>();
    }

    void Update()
    {
        if (target == null) return;

        Vector2 dir = target.position - transform.position;

        //Rotate to player
        float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion lookRot = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, rotationSpeed * Time.deltaTime);

        float distance = dir.magnitude;
        if (distance > fireRange) return;

        Vector2 forward = transform.right;  
        Vector2 toTarget = dir.normalized;   
        float angleToTarget = Vector2.Angle(forward, toTarget);

        //range
        if (angleToTarget < fireAngle)
        {
            shooter.TryShoot(forward);
        }
    }
}
