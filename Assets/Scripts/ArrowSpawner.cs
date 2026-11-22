using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{

    private float time;
    //arrow spawner objects
    public GameObject lowestYSpawn;
    public GameObject largestYSpawn;
    public float delay;
    public GameObject Arrow;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= delay)
        {
            spawnArrow();
            time = 0f;

        }
    }

    private void spawnArrow()
    {
        GameObject arrowSpawn = Instantiate(Arrow);

        arrowSpawn.transform.position = new Vector2(lowestYSpawn.transform.position.x, Random.Range(lowestYSpawn.transform.position.y, largestYSpawn.transform.position.y));
    }
}
