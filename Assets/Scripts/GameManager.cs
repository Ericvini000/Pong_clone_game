using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Configurações Gerais")]
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public BallController ballController;
    [Space()]
    public Vector2 startingVelocity = new Vector2(5f, 5f);
    public float ballDifficultMultiplier = 1.1f;

    [Header("Configurações Iniciais de pontuação")]
    public int winMaxPoints = 3;
    public int playerScore = 0;
    public int enemyScore = 0;
    public TextMeshProUGUI playerPointsText;
    public TextMeshProUGUI enemyPointsText;
    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;


    private void Start() {
        screenEndGame.SetActive(false);
        ResetGame();
    }

    public void ResetGame()
    {
        // Configurações iniciais das raquetes
        playerPaddle.position = new Vector3(7f, 0f,0f);
        enemyPaddle.position = new Vector3(-7f, 0f,0f);

        // Configurações iniciais da bola
        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        playerPointsText.text = playerScore.ToString();
        enemyPointsText.text = enemyScore.ToString();

    }

    public void ScorePlayer()
    {
        playerScore++;
        playerPointsText.text = playerScore.ToString();
        CheckWin();
    }
    public void ScoreEnemy()
    {
        enemyScore++;
        enemyPointsText.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if(enemyScore >= winMaxPoints || playerScore >= winMaxPoints)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Vitória " + winner;
        SaveController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
