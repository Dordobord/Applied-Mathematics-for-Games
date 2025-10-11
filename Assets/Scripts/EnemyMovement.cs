using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;   
    [SerializeField] private float moveSpeed = 3f;
    private int currentIndex = 0;

    void Start()
    {
        if (waypoints.Length > 0)
            transform.position = waypoints[currentIndex].position; 
    }

    void Update()
    {
        Transform target = waypoints[currentIndex];
        Vector2 targetPos = target.position;

        float directionX = targetPos.x - transform.position.x;
        float directionY = targetPos.y - transform.position.y;

        float distance = Mathf.Sqrt(directionX * directionX + directionY * directionY);

       if (distance > 0.1f)
        {
            float moveTargetX = directionX / distance * Time.deltaTime; //normalized
            float moveTargetY = directionY / distance * Time.deltaTime;

            transform.position = new Vector2
                (transform.position.x + moveTargetX,
                 transform.position.y + moveTargetY);
        }
        else
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                Debug.Log("Lose a point");
                Destroy(gameObject);
                return;
            }
        }
    }
}
