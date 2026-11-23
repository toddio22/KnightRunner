using UnityEngine;

public class GroundRecycle : MonoBehaviour
{
    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.position.x - transform.position.x > 6f)
        {
            Debug.Log(gameObject.name + " recycled");
            transform.position = new Vector3(transform.position.x + 18f, transform.position.y,transform.position.z);
        }
    }
}

