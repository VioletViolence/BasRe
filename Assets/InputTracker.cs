using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MouseTrack", Time.deltaTime , 1);
    }

    void MouseTrack()
    {
        Debug.Log("X:" + Input.mousePosition.x + " Y:"+ Input.mousePosition.y + " Z:" + Input.mousePosition.z);
    }
}
