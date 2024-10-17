using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RocketDashboard : MonoBehaviour
{
    public GameObject rocket;
    int rocketPosY;
    public Button shootButton;

    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;

    public void Start()
    {
        HighScoreTxt.text = $"High : {GetHighScore()} M";
    }
    private void Update()
    {
        rocketPosY = (int)rocket.transform.position.y;
        ScoreManager.instance.currentScore = rocketPosY;
        if (rocketPosY < 0)
        {
            ScoreManager.instance.currentScore = 0;
            currentScoreTxt.text = $"{ScoreManager.instance.currentScore} M";
        }
        else
        {
            currentScoreTxt.text = $"{GetCurrentScore()} M";
        }
    }

    public void HighScoreText()
    {
        if (Rocket.instance.fuel <= 0)
        {
            HighScoreTxt.text = $"High : {GetHighScore()} M";
            shootButton.interactable = false;
        }
    }

    public int GetCurrentScore()
    {
        return ScoreManager.instance.currentScore;
    }

    public int GetHighScore()
    {
        return ScoreManager.instance.highScore;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}