using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartGameEvent: MonoBehaviour
{
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] GameObject EnemyPrefab;
    GameObject SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = gameObject;
    }

    public void StartEvents()
    {
            SetEnemyStats();
            SetPlayerStats();
      
            Debug.Log("START!!!");
    }
    public void SetPlayerStats()
    {
        GameObject Place;
        GameObject[] Places = GameObject.FindGameObjectsWithTag("HandPlace");
        GameObject NewPlayer = Instantiate(PlayerPrefab, SpawnPoint.transform.position, Quaternion.identity);

        foreach (GameObject place in Places)
        {
            if (place.GetComponent<HandSpot>().isTaken == false)
            {
                Place = place;
                Place.GetComponent<HandSpot>().isTaken = true;
                Place.GetComponent<HandSpot>().ObjectHeld = NewPlayer;
                break;
            }
        }
    }
    public void SetEnemyStats()
    {
        GameObject Place;
        GameObject[] Places = GameObject.FindGameObjectsWithTag("HandPlace");
        GameObject NewPlayer = Instantiate(EnemyPrefab, SpawnPoint.transform.position, Quaternion.identity);
        var IPlayer = NewPlayer.GetComponent<Attack_Manager>();


        foreach (GameObject place in Places)
        {
            if (place.GetComponent<HandSpot>().isTaken == false)
            {
                Place = place;
                Place.GetComponent<HandSpot>().isTaken = true;
                Place.GetComponent<HandSpot>().ObjectHeld = NewPlayer;
                Place.GetComponent<HandSpot>().Placement();
                NewPlayer.GetComponent<Draggable>().PreviousTag = NewPlayer.tag;
                NewPlayer.tag = "Placed";
                NewPlayer.GetComponent<Attack_Manager>().enabled = false;
                NewPlayer.GetComponent<Melee>().enabled = false;
                break;
            }
        }
    }
}
