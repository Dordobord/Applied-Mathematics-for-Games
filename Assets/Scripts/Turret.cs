using UnityEngine;

public class Turret: MonoBehaviour
{
    private BulletShooter bulletShooter_;
    [SerializeField] private Transform target;
    [SerializeField] private float rotSpeed = 2f;
    [SerializeField] private float fireRange = 5f;
    [SerializeField] private float fireAngle = 10f;
    float currentAngle = 0f;

    void Start()
    {
        bulletShooter_ = GetComponent<BulletShooter>();
    }

    void Update()
    {
        if (target == null) return;
        
        float directionX, directionY;
        CalculateDirection(out directionX, out directionY);

        float distance = CalculateDistance(directionX, directionY); 
        
        if (distance > fireRange) return;

        float targetAngle = Mathf.Atan2(directionY, directionX) * Mathf.Rad2Deg; 
        currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, 0, currentAngle); 

        float normalizeX = directionX / distance; 
        float normalizeY = directionY / distance;

        float faceX = Mathf.Cos(currentAngle * Mathf.Deg2Rad); 
        float faceY = Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        float dot = (faceX * normalizeX) + (faceY * normalizeY); 

        float angleDifference = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if (angleDifference < fireAngle && bulletShooter_ != null)
        {
            bulletShooter_.TryShoot(target);
        }

    }

    private static float CalculateDistance(float directionX, float directionY)
    {
        return Mathf.Sqrt(directionX * directionX + directionY * directionY);
    }


    private void CalculateDirection(out float directionX, out float directionY)
    {
        directionX = target.position.x - transform.position.x;
        directionY = target.position.y - transform.position.y;
    }

}
