using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        //initialize button/get variable of button and set it to the Button component
        button = GetComponent<Button>();
        //to know when button was clicked
        button.onClick.AddListener(SetDifficulty);
        //reference to GameManager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function for level difficulty
    void SetDifficulty ()
    {
        Debug.Log(gameObject.name + " was clicked");
        //calling game manager to start
        gameManager.StartGame(difficulty);
    }
}
