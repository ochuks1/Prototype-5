using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    public GameObject titleScreen;
    private int score;
    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    //creating new IEnumerator SpawnTarget method
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
    {
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index]);
    }
    }

    //new method to update score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    //creating game over function
    public void GameOver()
    {
        //to activate restart button
        restartButton.gameObject.SetActive(true);
        //to make game over text appear
        gameOverText.gameObject.SetActive(true);
        //to stop spawning objects and score on game over
        isGameActive = false;
    }

    //creating new function to reload current scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //new method to start game;move everything from start function into here
    public void StartGame(int difficulty)
    {
        //set game active to true before coroutine
        isGameActive = true;
        //initializing score text needs to start before coroutine
        score = 0;

        //to start spawn timer
        StartCoroutine(SpawnTarget());
        //to update score text and variable
        UpdateScore(0);

        //to deactivate title screen object
        titleScreen.gameObject.SetActive(false);

        //spawn rate for difficulty level
        spawnRate /= difficulty;
    }
}
