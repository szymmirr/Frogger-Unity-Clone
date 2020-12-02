using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public static List<GameObject> prefabs;
    public float interval = 1.0f;
    public Vector2 velocity = Vector2.right;

    void SpawnNext()
    {
        GameObject g = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
        g.GetComponent<Rigidbody2D>().velocity = velocity;
        prefabs.Add(g);
    }

    void Start()
    {
        prefabs = new List<GameObject>();
        InvokeRepeating("SpawnNext", 0, interval);
    }
}
