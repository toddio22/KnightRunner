using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{

    private float time;
    //arrow spawner objects
    public GameObject lowestYSpawn;
    public GameObject largestYSpawn;
    public float delay;
    public Transform player;
    public GameObject Arrow;
    public GameObject Enemy;
    public GameObject Coin;
    public GameObject Spike;
    public GameObject Shield;
    public GameObject Jump;
    public GameObject Speed;


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
            spawnRandomObject();
            time = 0f;

        }
       
        transform.position = new Vector3(player.position.x + 5f, transform.position.y, transform.position.z);
    }

    private void spawnRandomObject()
    {
        int spawnChoice = Random.Range(0, 10);

        switch (spawnChoice)
        {
            case 0:
            case 1:
                GameObject arrowSpawn = Instantiate(Arrow);

                arrowSpawn.transform.position = new Vector2(
                    lowestYSpawn.transform.position.x,
                    Random.Range(lowestYSpawn.transform.position.y, largestYSpawn.transform.position.y)
                );
                break;

            case 2:
            case 3:
            case 4:
                GameObject coinSpawn = Instantiate(Coin);

                coinSpawn.transform.position = new Vector2(
                    lowestYSpawn.transform.position.x,
                    Random.Range(lowestYSpawn.transform.position.y, largestYSpawn.transform.position.y)
                );
                break;

            case 5:
            case 6:
                GameObject spikeSpawn = Instantiate(Spike);

                spikeSpawn.transform.position = lowestYSpawn.transform.position;
                break;

            case 7:
            case 8:
                GameObject enemySpawn = Instantiate(Enemy);

                enemySpawn.transform.position = lowestYSpawn.transform.position;
                break;

            case 9:
                GameObject shieldSpawn = Instantiate(Shield);

                shieldSpawn.transform.position = lowestYSpawn.transform.position;
                break;

            case 10:
                int powerupChoice = Random.Range(0, 2);

                if (powerupChoice == 0)
                {
                    GameObject jumpSpawn = Instantiate(Jump);
                    jumpSpawn.transform.position = lowestYSpawn.transform.position;
                }
                else
                {
                    GameObject speedSpawn = Instantiate(Speed);
                    speedSpawn.transform.position = lowestYSpawn.transform.position;
                }
                break;
        }
    }
}
