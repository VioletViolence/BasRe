using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawStageEvent : MonoBehaviour
{
    [SerializeField] GameObject DrawMenu;

    public void DrawEvents()
    {
        DrawMenu.SetActive(true);
    }
}
