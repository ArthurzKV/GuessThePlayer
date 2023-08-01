using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int currentScore = 0;
    private string scoreKey = "PlayerScore";

    private void Start()
    {
        LoadScore();
        UpdateScoreText();
    }

    private void Update()
    {
    }

    public void IncreaseScore(int points)
    {
        currentScore += points;
        SaveScore();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt(scoreKey, currentScore);
        PlayerPrefs.Save();
    }

    private void LoadScore()
    {
        if (PlayerPrefs.HasKey(scoreKey))
        {
            currentScore = PlayerPrefs.GetInt(scoreKey);
        }
        else
        {
            // Si no hay puntaje guardado, iniciamos con 0 puntos
            currentScore = 0;
        }
    }
}
