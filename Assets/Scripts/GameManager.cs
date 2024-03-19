using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

    public bool isGameover = false; 
    public TMP_Text scoreText; 

    public bool isLevelUp = false;
    public bool isInGame = false;

    public int score = 0; 
    public GameObject[] characters;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.LogWarning("Warning");
            Destroy(gameObject);
        }

    }

    public void AddScore(int newScore)
    {
        // if (isGameover)
        // {
            score += newScore;
            //scoreText.text = score.ToString();
        // }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
    }


    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0); 
        score = 0; 
    }
}