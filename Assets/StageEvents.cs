using UnityEngine.Events;
using System.Collections;
using UnityEngine;

public class StageEvents : MonoBehaviour
{
    public UnityEvent StartGame = new UnityEvent();
    public UnityEvent Draw = new UnityEvent();
    public UnityEvent Prefase = new UnityEvent();
    public UnityEvent Battle = new UnityEvent();
    public UnityEvent LeaderboardPlacement = new UnityEvent();
    public UnityEvent HuntersDeck = new UnityEvent();
    public UnityEvent GameOver = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        UnityEvent[] Stages = new UnityEvent[] {Draw,Prefase,Battle,LeaderboardPlacement};
        if (StartGame.GetPersistentEventCount() > 0)
        {
            StartGame.Invoke();
        }
        StartCoroutine("Game",Stages);
    }

    IEnumerator Game(UnityEvent[] Stages)
    {
        foreach(UnityEvent Event in Stages)
        {
            yield return new WaitForSeconds(30);
            Event.Invoke();
        }
    }
    
}
