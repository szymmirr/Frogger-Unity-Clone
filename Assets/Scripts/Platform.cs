using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool platformDrowned = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.transform.parent = null;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        coll.transform.parent = null;
        if (coll.name == "Frog")
        {
            if(platformDrowned == false)
            {
                coll.transform.parent = transform;
            }
            else
            {
                coll.transform.parent = null;
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        coll.transform.parent = null;
    }
}
