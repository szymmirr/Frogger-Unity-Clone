using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    int jumpPoints = 10;
    int levelScore = 0;
    static float defaultFurthestPosition = Respawn.startPositionY;
    float furthestPosition = defaultFurthestPosition;

    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(GameObject.Find("Frog") != null)
        {
            if (GameObject.Find("Frog").GetComponent<Frog>().isJumping() == false && GameObject.Find("Frog").transform.position.y > furthestPosition)
            {
                Variables.totalScore += jumpPoints;
                levelScore += jumpPoints;
                furthestPosition = GameObject.Find("Frog").transform.position.y;
            }
        }
        
        if(GameObject.Find("Score") != null)
        {
            scoreText.text = "SCORE:\n" + Variables.totalScore;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Variables.totalScore += (int)(Timing.levelTime - Time.timeSinceLevelLoad) * jumpPoints;
        levelScore += (int)(Timing.levelTime - Time.timeSinceLevelLoad) * jumpPoints;
        scoreText.text = "SCORE:\n" + Variables.totalScore;
        GameOver.NextLevel();
    }
}
