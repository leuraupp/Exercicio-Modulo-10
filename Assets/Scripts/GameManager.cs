using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public BallController ball;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointPlayer;
    public TextMeshProUGUI textPointEnemy;

    public int winPoints = 2;

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;

    private void Start() {
        ResetGame();
    }

    private void ResetGame() {
        playerPaddle.position = new Vector3(-7f,0f,0f);
        enemyPaddle.position = new Vector3(7f,0f,0f);

        ball.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointPlayer.text = playerScore.ToString();
        textPointEnemy.text = enemyScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer() {
        playerScore++;
        textPointPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy() {
        enemyScore++;
        textPointEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin() {
        if (enemyScore >= winPoints || playerScore >= winPoints) {
            //ResetGame();
            EndGame();
        }
    }

    public void EndGame()
 {
 screenEndGame.SetActive(true);
 string winner = SaveController.Instance.GetName(playerScore > enemyScore);
 textEndGame.text = "Vit�ria "+winner;
 SaveController.Instance.SaveWinner(winner);
 Invoke("LoadMenu", 2f);
 }

    private void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }
}
