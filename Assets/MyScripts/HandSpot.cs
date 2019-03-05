using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSpot : MonoBehaviour
{
    public bool isTaken;
    public GameObject ObjectHeld;
    // Start is called before the first frame update
    void Start()
    {
        isTaken = false;
    }

    public void Placement()
    {
        if (ObjectHeld != null)
        {
            ObjectHeld.transform.position = gameObject.transform.position;
            ObjectHeld.transform.position.Set(ObjectHeld.transform.position.x,
                ObjectHeld.transform.position.y + ObjectHeld.GetComponent<CapsuleCollider>().height,
                ObjectHeld.transform.position.z);
        }
    }
}
