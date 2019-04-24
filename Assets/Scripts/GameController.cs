using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text hardText;

    private bool gameOver;
    private bool restart;
    private int score;
    public float speed;

    public AudioSource BackgroundMusic;
    public AudioSource Win;
    public AudioSource Lose;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        hardText.text = "Press E to enter Hard Mode";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        speed = 1;
        BackgroundMusic.Play();
    }

    private void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("Space Shooter");
            }
        }

        if (Input.GetKey("escape"))
            Application.Quit();

        if(Input.GetKeyDown(KeyCode.E))
        {
            Hard();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Easy();
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[UnityEngine.Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restartText.text = "Press 'T' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if(score>=100)
        {
            winText.text = "You win!";
            gameOver = true;
            restart = true;
            BackgroundMusic.Stop();
            Win.Play();
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over! Game Created by Audrey Luce";
        gameOver = true;
        BackgroundMusic.Stop();
        Lose.Play();
    }

    public void Hard()
    {
        speed = 2.5f;
        hardText.text = "Press R to exit Hard Mode";
    }

    public void Easy()
    {
        hardText.text = "Press E to enter Hard Mode";
        speed = 1;
    }
}
