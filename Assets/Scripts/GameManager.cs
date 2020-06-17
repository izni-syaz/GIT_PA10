using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager thisManager = null;  
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    private int Score = 0;

    public enum GameState { GamePause, GameOver };
    private GameState CurrentState = GameState.GamePause;

    void Start()
    {
        thisManager = this;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (CurrentState == GameState.GamePause && Input.GetKeyDown(KeyCode.Return))
            StartGame();

        if(CurrentState == GameState.GameOver && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateScore(int value)
    {
        Score += value;
        Txt_Score.text = "SCORE : " + Score;
    }

    private void StartGame()
    {
        Score = 0;
        Time.timeScale = 1;
        Txt_Message.text = "";
        Txt_Score.text = "SCORE : 0";
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        CurrentState = GameState.GameOver;
        Txt_Message.text = "GAMEOVER! \nPRESS ENTER TO RESTART GAME.";
        Txt_Message.color = Color.red;
        
    }

    public void UpdateScore()
    {
        Score += 1;
        Txt_Score.text = "SCORE: " + Score;
    }
}
