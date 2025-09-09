using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{
    public Transform target;
    private SpriteRenderer sr;
    public float speed = 5;
    public float shakeAmount = 0.1f;   
    public float trgrDist = 3f;
    public float restartDist = 1f;
    private int direction = 1;
    private float baseX, baseY;
    public Text winText;


    void Start()
    {
        sr = target.GetComponent<SpriteRenderer>();
        baseX = target.position.x; //need 2 save the pos of target
        baseY = target.position.y;
    }

    void Update()
    {

        MovementControls();
        CalculateDistance();
    }

    private void MovementControls()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        if (Input.GetKey(KeyCode.W))
        {
            y += speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            y -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x += speed * Time.deltaTime;
        }

        transform.position = new Vector2(x, y); 
    }

    private void CalculateDistance()
    {
        if (target != null)
        {
            var distance = Mathf.Sqrt(
                Mathf.Pow(target.position.x - transform.position.x, 2) +
                Mathf.Pow(target.position.y - transform.position.y, 2)
            );
            //var vectorDist = Vector3.Distance(target.position, transform.position);
            //Debug.Log($"Distance {distance:F2}, Vector {vectorDist:F2}");
            Debug.Log($"Distance {distance:F2}");

            if (distance < trgrDist) //Target Shake Cube
            {
                sr.color = Color.red;
                float x = baseX + (shakeAmount * direction);
                float y = baseY;

                target.position = new Vector2(x, y);
                direction *= -1;

                if (distance < restartDist)
                {
                    ReloadScene();
                }

            }
            else
            {
                sr.color = Color.white;
                target.position = new Vector2(baseX, baseY);
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


