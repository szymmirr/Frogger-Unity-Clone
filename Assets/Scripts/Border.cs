using UnityEngine;

public class Border : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Frog")
        {
            GameOver.Collision();
        }
        else
        {
            Destroy(coll.gameObject);
            Spawn.prefabs.Remove(coll.gameObject);
        }
    }
}
