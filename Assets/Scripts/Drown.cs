using System.Collections;
using UnityEngine;

public class Drown : MonoBehaviour
{
    float drownInterval = 2.0f;
    string platformName = "Platform_large(Clone)";
    float waitTime = 1.0f;

    void Start()
    {
        InvokeRepeating("DrownPlatform", drownInterval, drownInterval);
    }

    IEnumerator DrowningCoroutine(GameObject randomPlatform, Color originalColor)
    {
        yield return new WaitForSeconds(waitTime);
        if (randomPlatform != null)
        {
            randomPlatform.GetComponent<SpriteRenderer>().enabled = false;
            randomPlatform.GetComponent<Platform>().platformDrowned = true;
            StartCoroutine(FlowingOutCoroutine(randomPlatform, originalColor));
        }
    }

    IEnumerator FlowingOutCoroutine(GameObject randomPlatform, Color originalColor)
    {
        yield return new WaitForSeconds(waitTime);
        if(randomPlatform != null)
        {
            randomPlatform.GetComponent<SpriteRenderer>().enabled = true;
            randomPlatform.GetComponent<Platform>().platformDrowned = false;
            randomPlatform.GetComponent<Renderer>().material.color = originalColor;
        }
    }

    void DrownPlatform()
    {
        System.Random random = new System.Random();
        var index = random.Next(Spawn.prefabs.Count);
        var randomPlatform = Spawn.prefabs[index];

        if (randomPlatform.name == platformName)
        {
            Color originalColor = randomPlatform.GetComponent<Renderer>().material.color;
            randomPlatform.GetComponent<Renderer>().material.color = Color.cyan;
            StartCoroutine(DrowningCoroutine(randomPlatform, originalColor));
        }
    }
}
