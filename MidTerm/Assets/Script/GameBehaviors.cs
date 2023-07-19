using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System.Reflection;
using UnityEngine.SceneManagement;

public class GameBehaviors : MonoBehaviour
{
    public static GameBehaviors Instance;
    public GameState State;
    [SerializeField] TextMeshProUGUI _messagesGUI;
    [SerializeField] TextMeshProUGUI scoreGUI;
    [SerializeField] TextMeshProUGUI endGameGUI; 


    private void Awake()
    {
        // Singleton Pattern
        if (Instance != this && Instance != null)
            Destroy(this);
        else
            Instance = this;


    }

    void Start()
    {
        // Find all objects with the "Enemy" tag
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Enemy");

        // Access and modify components on the clones
        foreach (GameObject clone in clones)
        {
            NavMeshAgent navMeshAgent = clone.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null)
            {
                navMeshAgent.enabled = true; // Enable the NavMeshAgent component
            }
        }

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && State != GameState.GameOver)
        {
            if (State == GameState.Play)
            {
                // Switch to play game state
                Time.timeScale = 0f;
                State = GameState.Pause;
                _messagesGUI.enabled = true;
            }
            else
            {
                // Switch to pause game state
                Time.timeScale = 1f;
                State = GameState.Play;
                _messagesGUI.enabled = false;
            }
        }
        if (GameObject.FindWithTag("Player") == null)
        {
       
            GameOverla();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Reset(); 
        }
    }

    private int score;
    public int Score
    {
        get => score;

        set
        {
            score = value;
            scoreGUI.text = Score.ToString();
        }
    }

    private void GameOverla()
    {
        State = GameState.GameOver;
        Time.timeScale = 0f; 
        endGameGUI.text = $"Your Score is {score}! \n\n\nPress space bar to restart.";
        endGameGUI.enabled = true;
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        State = GameState.Play;
        Time.timeScale = 1f; 
    }


}
