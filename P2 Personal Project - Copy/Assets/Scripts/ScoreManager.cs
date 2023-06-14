using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private float timeElapsed = 0f;
    public TextMeshProUGUI scoreText;

    private bool isScoreFrozen = false;

    private void Start()
    {
        //Reference the score text
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        //Check if I attached the score text component to the MenuManager
        if (scoreText == null)
        {
            Debug.LogError("Score text component not found.");
        }
    }

    private void Update()
    {
        //Freeze the score
        if (!isScoreFrozen)
        {
            timeElapsed += Time.deltaTime;

            // Increment the score by 1 every millisecond
            if (timeElapsed >= 0.001f)
            {
                score += 1;
                timeElapsed -= 0.001f;
            }

            // Update the score display
            UpdateScoreDisplay();
        }
    }

    private void UpdateScoreDisplay()
    {
        //Display the score
        if (scoreText != null)
        {
            scoreText.text = "DISTANCE RAN: " + score.ToString() + " km";
        }
    }

    public void FreezeScore()
    {
        //Method to freeze the score
        isScoreFrozen = true;
    }

    public void UnfreezeScore()
    {
        //Method to unfreeze the score
        isScoreFrozen = false;
    }

    public void ResetScore()
    {
        //Set the score to 0
        score = 0;
        timeElapsed = 0f;
        UpdateScoreDisplay();
    }
}