using System.Runtime.CompilerServices;
using UnityEngine;

public enum CollectableType
{
    Score,
    JumpBoost,
    SpeedBoost,
    Shield
}

public class CollectableController : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController pc;
    [SerializeField]
    private CollectableType collectableType;
    private bool collected = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collectable Triggered");
        Debug.Log(collectableType);

        if (collected)
        {
            return;
        }

        collected = true;

        if(collision.CompareTag("Player"))
        {
            Debug.Log("Collectable name: " + gameObject.name);
            switch (collectableType)
            {
                case CollectableType.Score:
                    Debug.Log(collision.gameObject.name);
                    gameManager.coinCollection();
                    break;

                case CollectableType.JumpBoost:
                    gameManager.jumpBoost();
                    break;

                case CollectableType.SpeedBoost:
                    gameManager.speedBoost();
                    break;

                case CollectableType.Shield:
                    gameManager.addShield();
                    pc.equipShield(gameObject);
                    return;
            }
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }
    }
}
