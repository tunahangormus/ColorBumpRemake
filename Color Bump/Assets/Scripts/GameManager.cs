using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameEnded = false;
    private bool isGameStarted = false;
    private bool win = false;
    private GameState currentGameState;

    private UIController uIController;

    public bool IsGameEnded { get => isGameEnded; set => isGameEnded = value; }
    public bool Win { get => win; set => win = value; }
    public GameState CurrentGameState { get => currentGameState; }
    public bool IsGameStarted { get => isGameStarted; set => isGameStarted = value; }

    void Awake()
    {
        instance = this;
        currentGameState = GameState.Waiting;
        Time.timeScale = 1f;
    }

    void Start(){
        uIController = UIController.instance;
    }

    void Update()
    {

        SetGameState();

        if (currentGameState == GameState.Ended)
            StartCoroutine(EndGame());

        if (Input.GetMouseButton(0) && currentGameState == GameState.Waiting)
            StartGame();
    }

    void StartGame()
    {
        isGameStarted = true;
        uIController.DestroyTouchToStart();
    }

    void SetGameState()
    {
        if (isGameStarted){
            currentGameState = GameState.Started;
        }

        if (isGameEnded)
        {
            currentGameState = GameState.Ended;
            isGameStarted = false;
        }


    }

    IEnumerator EndGame()
    {
        SlowTime();
        yield return new WaitForSeconds(0f * Time.timeScale);
        if (win)
            uIController.Win();
        else
            uIController.GameOver();
            
    }


    void SlowTime()
    {
        Time.timeScale = 0.2f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}


public enum GameState
{
    Waiting,
    Started,
    Ended,
}
