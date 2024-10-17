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
    public static Rocket instance;

    private Rigidbody2D _rb2d;

    public RocketEnergySystem RocketEnergySystem;
    public RocketDashboard rocketDashboard;

    public float fuel = 100f;
    private readonly float SPEED = 10f;
    public readonly float FUELPERSHOOT = 10f;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        fuel -= FUELPERSHOOT;
        rocketDashboard.HighScoreText();
        RorketAddForce();
    }

    public void RorketAddForce()
    {
        _rb2d.velocity = new Vector2(0f, SPEED);
        _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
    }
}
