using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int currentScore = 0;
    public int highScore {  get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(!PlayerPrefs.HasKey(nameof(highScore)))
        {
            PlayerPrefs.SetInt(nameof(highScore), 0);
        }
        else
        {
            highScore = PlayerPrefs.GetInt(nameof(highScore));
        }
    }

    private void Update()
    {
        if(currentScore > highScore)
        {
            PlayerPrefs.SetInt(nameof(highScore), currentScore);
            highScore = currentScore;
        }
    }
}
