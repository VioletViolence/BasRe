using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Reset_Handler : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
       
    }
    public void DoReset()
    {
        var TextFields = FindObjectsOfType<TMP_Text>();
        foreach (TMP_Text text in TextFields)
        {
            if (text.name != "Parameter Tag" && text.name != "CharacterTag" && text.name != "VS" &&
        }
    }
    public void Reload()
    {
        var current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }
}
