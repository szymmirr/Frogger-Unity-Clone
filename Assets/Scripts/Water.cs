using UnityEngine;

public class Water : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.name == "Frog")
        {
            if (!coll.GetComponent<Frog>().isJumping())
            {
                if (coll.transform.parent == null)
                {
                    GameOver.Collision();
                }
            }
        }
    }
}
