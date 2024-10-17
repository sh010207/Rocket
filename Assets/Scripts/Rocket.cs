using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float fuel = 100f;

    public GameObject rocket;
    public Button shootButton;
    int rocketPosY;

    private readonly float SPEED = 20f;
    private readonly float FUELPERSHOOT = 10f;

    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;


    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        HighScoreTxt.text = $"High : {GetHighScore()} M";
    }

    private void Update()
    {
        rocketPosY = (int)rocket.transform.position.y;
        ScoreManager.instance.currentScore = rocketPosY;
        if(rocketPosY < 0 )
        {
            ScoreManager.instance.currentScore = 0;
            currentScoreTxt.text = $"{ScoreManager.instance.currentScore} M";
        }
        else
        {
            currentScoreTxt.text = $"{GetCurrentScore()} M";
        }
    }


    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        fuel -= FUELPERSHOOT;

        if (fuel == 0)
        {
            HighScoreTxt.text = $"High : {GetHighScore()} M";
            shootButton.interactable = false;

        }
        RorketAddForce();
    }

    public void RorketAddForce()
    {
        _rb2d.velocity = new Vector2(0f, SPEED);
        _rb2d.AddForce(_rb2d.velocity);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public int GetCurrentScore()
    {
        return ScoreManager.instance.currentScore;
    }

    public int GetHighScore()
    {
        return ScoreManager.instance.highScore;
    }
}
