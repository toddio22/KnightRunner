using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    [SerializeField]
    private TMP_Text scoreDisplay;
    private PlayerController pc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreDisplay.text = "Score: " + score;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerDeath()
    {
        if(pc.shielded)
        {
            pc.shielded = false;
            if(pc.equippedShield != null)
            {
                Destroy(pc.equippedShield);
            }
        }
        else
        {
            saveScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void coinCollection()
    {
        
        score += 10;
        //Debug.Log("Score: " + score);
        scoreDisplay.text = "Score: " + score;
    }

    public void jumpBoost()
    {
        pc.jumpForce += 2;
    }

    public void speedBoost()
    {
        pc.movementSpeed += 2;
    }

    public void addShield()
    {
        pc.shielded = true;
    }

    private void saveScore()
    {
        string path = Application.persistentDataPath + "/scores.txt";
        Debug.Log(path);

        List<int> scores = new List<int>();

        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                scores.Add(int.Parse(line));
            }
        }

        scores.Add(score);
        scores.Sort();
        scores.Reverse();
        while (scores.Count > 5)
        {
            scores.RemoveAt(scores.Count - 1);
        }
        List<string> scoreStrings = new List<string>();

        foreach (int s in scores)
        {
            scoreStrings.Add(s.ToString());
        }
        File.WriteAllLines(path, scoreStrings);

        foreach (int s in scores)
        {
            Debug.Log(s);
        }
    }

}
