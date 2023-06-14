using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public Button startButton;
    public ScoreManager scoreManager;
    public CarSpawnManager carSpawner;
    public GameObject restartButton;
    public GameObject player; 

    private Vector3 playerStartPosition;
    private Quaternion playerStartRotation;

    private void Start()
    {
        //Score, car spawner, and restart button are disabled in menu
        scoreManager.enabled = false;
        carSpawner.enabled = false;
        scoreManager.scoreText.gameObject.SetActive(false);
        restartButton.SetActive(false);

        //Reset player's position + rotation
        playerStartPosition = player.transform.position;
        playerStartRotation = player.transform.rotation;
    }

    public void StartGame()
    {
        //Enable the score, car spawner
        scoreManager.enabled = true;
        carSpawner.enabled = true;
        scoreManager.scoreText.gameObject.SetActive(true);

        //Disable title text and start button
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

    public void PlayerDied()
    {
        //When player dies, disable the score and car spawner
        scoreManager.enabled = false;
        carSpawner.enabled = false;

        //Enable restart button
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        //When game resets, score resets and car spawner is enabled
        scoreManager.ResetScore();
        scoreManager.enabled = true;
        carSpawner.enabled = true;
        scoreManager.scoreText.gameObject.SetActive(true);
        restartButton.SetActive(false);

        //Respawn the player
        ResetPlayer();
    }

    private void ResetPlayer()
    {
        //Respawn the player
        player.SetActive(true);
        player.transform.position = playerStartPosition;
        player.transform.rotation = playerStartRotation;
        var playerController = player.GetComponent<PlayerController>();
        // Make sure the player can move after respawning
        playerController.canMove = true;
         
    }
}