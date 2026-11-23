using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI score5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        displayScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void highScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void displayScores()
    {
        string path = Application.persistentDataPath + "/scores.txt";

        if (!File.Exists(path))
        {
            return;
        }

        string[] scores = File.ReadAllLines(path);

        if (scores.Length > 0) score1.text = scores[0];
        if (scores.Length > 1) score2.text = scores[1];
        if (scores.Length > 2) score3.text = scores[2];
        if (scores.Length > 3) score4.text = scores[3];
        if (scores.Length > 4) score5.text = scores[4];
    }
}
