using UnityEngine;
using TMPro;

public class Timing : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public static float levelTime;

    void Start()
    {
        timeText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
        levelTime = Variables.levelTimes[Variables.level-1];
        Variables.timeLeft = levelTime;
    }

    void Update()
    {
        if (Variables.timeLeft >= 0)
        {
            Variables.timeLeft -= Time.deltaTime;
        }

        if (GameObject.Find("Time") != null)
        {
            timeText.text = "TIME LEFT:\n" + (int)Variables.timeLeft;
        }
    }

    public static void ResetTimer()
    {
        Variables.timeLeft = levelTime;
    }
}
