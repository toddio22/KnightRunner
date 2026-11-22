using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    [SerializeField]
    private TMP_Text scoreDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreDisplay.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void coinCollection()
    {
        
        score += 10;
        //Debug.Log("Score: " + score);
        scoreDisplay.text = "Score: " + score;
    }
}
