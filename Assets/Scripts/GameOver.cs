using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public static SpriteRenderer winScreen;
    public static SpriteRenderer loseScreen;
    public static TextMeshProUGUI scoreText;
    static float waitTime = 3.0f;
    static int requiredCompletions = 1; //3
    static int completions = 0;
    public static bool collision = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        winScreen = GameObject.Find("Win").GetComponent<SpriteRenderer>();
        loseScreen = GameObject.Find("Lose").GetComponent<SpriteRenderer>();
        winScreen.enabled = false;
        loseScreen.enabled = false;
    }

    public static void NextLevel()
    {
        completions += 1;
        if (completions >= requiredCompletions)
        {
            GameOver.Win(Variables.totalScore);
        }

        Respawn.RespawnFrog();
        Timing.ResetTimer();
    }

    public static void GameEnd(int score)
    {
        Destroy(GameObject.Find("Game"));
        Destroy(GameObject.Find("Background"));
        Destroy(GameObject.Find("Frog"));
        scoreText = GameObject.Find("GameOverScore").GetComponent<TextMeshProUGUI>();
        scoreText.text = "SCORE: " + score;
    }

    public static IEnumerator PopupCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        Variables.level += 1;
        SceneManager.LoadScene("Level" + Variables.level, LoadSceneMode.Single);
    }

    public static void Win(int score)
    {
        GameEnd(score);
        winScreen.enabled = true;
        instance.StartCoroutine(PopupCoroutine());
    }

    public static void Lose(int score)
    {
        GameEnd(score);
        loseScreen.enabled = true;
    }

    public static void Collision()
    {
        collision = true;
    }
}
