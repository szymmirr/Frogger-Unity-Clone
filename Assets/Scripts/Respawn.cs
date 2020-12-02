using System.Collections;
using UnityEngine;
using TMPro;

public class Respawn : MonoBehaviour
{
    public static Respawn instance;
    public static float startPositionX = -0.5f;
    public static float startPositionY = -5.5f;
    public TextMeshProUGUI livesText;
    static float respawnTime = 2.0f;
    static Vector2 startPosition = Vector2.zero;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        startPosition = new Vector2(startPositionX, startPositionY);
        GameObject.Find("Frog").transform.position = startPosition;
        livesText = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
        livesText.text = "LIVES: " + Variables.lives;
    }

    public static IEnumerator FrogSpawnCoroutine()
    {
        if (GameObject.Find("Frog") != null)
        {
            GameObject.Find("Frog").GetComponent<Frog>().isAlive = false;
        }

        yield return new WaitForSeconds(respawnTime);

        if (GameObject.Find("Frog") != null)
        {
            startPosition = new Vector2(startPositionX, startPositionY);
            GameObject.Find("Frog").GetComponent<Frog>().isAlive = true;
            GameObject.Find("Frog").transform.position = startPosition;
        }
    }

    public static void RespawnFrog()
    {
        if (GameObject.Find("Frog") != null)
        {
            Vector2 deadFrog = new Vector2(-100f, -100f);
            GameObject.Find("Frog").transform.position = deadFrog;
        }
        instance.StartCoroutine(FrogSpawnCoroutine());
    }

    void Update()
    {
        if (Variables.timeLeft < 0 || GameOver.collision == true)
        {
            RespawnFrog();
            Variables.lives -= 1;

            if (GameObject.Find("Lives") != null)
            {

                livesText.text = "LIVES: " + Variables.lives;
            }

            Timing.ResetTimer();
            GameOver.collision = false;
        }

        else if (Variables.lives <= 0)
        {
            GameOver.Lose(Variables.totalScore);
        }
    }
}
