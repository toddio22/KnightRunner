using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float patrolDistance;
    private Rigidbody2D rb;
    private float startPosition;
    private float direction = 1f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
    }

    private void patrol()
    {
        transform.position = new Vector2(transform.position.x + (moveSpeed * direction * Time.deltaTime), transform.position.y);
        
        if (transform.position.x > startPosition + patrolDistance)
        {
            direction = -1f;
            flipSprite(direction);
        }
        else if (transform.position.x < startPosition - patrolDistance)
        {
            direction = 1f;
            flipSprite(direction);
        }
    }

    private void flipSprite(float d)
    {
        if (d > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (d < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
