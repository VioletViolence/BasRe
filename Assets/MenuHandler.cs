using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject Game;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject EditorMenu;
    private string[] CheatCode = {"P","L","A","Y"};
    private int index;
    // Start is called before the first frame update
    private void Start()
    {
       // Game = GameObject.Find("Game");
      //  MainMenu = GameObject.Find("MainMenu");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           if(Game.activeSelf == true && MainMenu.activeSelf == false)
            {
                Game.SetActive(false);
                MainMenu.SetActive(true);
            }
           else if(Game.activeSelf == false && MainMenu.activeSelf == true)
            {
                Game.SetActive(true);
                MainMenu.SetActive(false);
            }
            else
            {
                if (EditorUtility.DisplayDialog("This shouldn't have happened", "Something is wrong with menu script and you get a free" +
                    "cookie for finding this secret message", "Back to normal"))
                {
                    Game.SetActive(true);
                    MainMenu.SetActive(false);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            EditorScript(true);
        }
    }

    private void EditorScript(bool A)
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(CheatCode[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if(index == CheatCode.Length)
        {
            GameObject.Find("EditorMenu").SetActive(true);
            GameObject salute = Instantiate(Resources.Load("EditorGreeting") as GameObject);
            Destroy(salute, salute.GetComponent<ParticleSystem>().main.duration);
        }
    }
}
