using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private float arrowSpeed;
    private Rigidbody2D arrowRB;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arrowRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveArrowLeft();
        
    }


    private void moveArrowLeft()
    {
        arrowRB.linearVelocity = new Vector2(arrowSpeed * -1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Killzone"))
        {
            Destroy(this.gameObject);
        }
    }
}
