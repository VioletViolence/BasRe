using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountersHandler : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject EnemySpawn;
    // Player stats
    private int PlayerDeathCounter = 0;
    private int PlayerHealth;
    private int PlayerDmg;
    private float PlayerAtkSpeed;
    private int PlayerBltSpeed;
    private int PlayerArmor;
    private int PlayerMagRes;
    private int PlayerMagDmgPercent;

    // Enemy stats
    private int EnemyDeathCounter = 0;
    private int EnemyHealth;
    private int EnemyDmg;
    private float EnemyAtkSpeed;
    private int EnemyBltSpeed;
    private int EnemyArmor;
    private int EnemyMagRes;
    private int EnemyMagDmgPercent;

    // Editor interface
            // Player and Enemy script instances
            Attack_Manager Player;
            Attack_Manager Enemy;

            // Buttons
            private GameObject EnemySave;
            private GameObject EnemyReset;
            private GameObject EnemyReload;
            private GameObject PlayerSave;
            private GameObject PlayerReset;
            private GameObject PlayerReload;

            // Sliders and Counters
            TMP_Text EnemyHealthCounter;
            TMP_Text PlayerHealthCounter;
            Slider EnemySlider;
            Slider PlayerSlider;

    // Start is called before the first frame update
    void Start()
    {
        // Reference intialisations
            Enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Attack_Manager>();
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack_Manager>();
            PlayerHealthCounter = GameObject.Find("PlayerHealthScore").GetComponent<TMP_Text>();
            EnemyHealthCounter = GameObject.Find("EnemyHealthScore").GetComponent<TMP_Text>();
            EnemySlider = GameObject.Find("EnemyHealth").GetComponent<Slider>();
            PlayerSlider = GameObject.Find("PlayerHealth").GetComponent<Slider>();

        // Enemy Counters
            EnemyHealth = Enemy.GetHealth();
            EnemyDmg = Enemy.GetAttackDamage();
            EnemyAtkSpeed = Enemy.GetAttackSpeed();
            EnemyBltSpeed = Enemy.GetBulletSpeed();
            EnemyArmor = Enemy.GetArmor();
            EnemyMagRes = Enemy.GetMagicResist();
            EnemyMagDmgPercent = Enemy.GetIsMagical();


        // Player Counters
            PlayerHealth = Player.GetHealth();
            PlayerDmg = Player.GetAttackDamage();
            PlayerAtkSpeed = Player.GetAttackSpeed();
            PlayerBltSpeed = Player.GetBulletSpeed();
            PlayerArmor = Player.GetArmor();
            PlayerMagRes = Player.GetMagicResist();
            PlayerMagDmgPercent = Player.GetIsMagical();


        // Slider initialisation
            EnemySlider.maxValue = EnemyHealth;
            EnemyHealthCounter.text = EnemySlider.maxValue.ToString();
            PlayerSlider.maxValue = PlayerHealth;
            PlayerHealthCounter.text = PlayerSlider.maxValue.ToString();
        //  Debug.Log(Time.realtimeSinceStartup);
    }

    // Update is called once per frame
    void Update()
    {
        EnemySlider.value = Enemy.GetHealth();
        EnemyHealthCounter.text = EnemySlider.value.ToString();
        PlayerSlider.value = Player.GetHealth();
        PlayerHealthCounter.text = PlayerSlider.value.ToString();
    }
    
    public void SetPlayerStats()
    {
        GameObject Place;
        GameObject[] Places = GameObject.FindGameObjectsWithTag("HandPlace");
        Transform EnemyPosition = GameObject.FindGameObjectWithTag("Enemy").transform;
        GameObject NewPlayer = Instantiate(PlayerPrefab, SpawnPoint.transform.position, Quaternion.identity);
        NewPlayer.transform.LookAt(EnemyPosition);
        var IPlayer = NewPlayer.GetComponent<Attack_Manager>();
            IPlayer.SetHealth(int.Parse(GameObject.Find("PHealth").GetComponent<TMP_InputField>().text));
            IPlayer.SetAttackDamage(int.Parse(GameObject.Find("PAtkSpeed").GetComponent<TMP_InputField>().text));
            IPlayer.SetAttackSpeed(float.Parse(GameObject.Find("PADmg").GetComponent<TMP_InputField>().text));
            IPlayer.SetBulletSpeed(int.Parse(GameObject.Find("PBltSpeed").GetComponent<TMP_InputField>().text));
            IPlayer.SetArmor(int.Parse(GameObject.Find("PArmor").GetComponent<TMP_InputField>().text));
            IPlayer.SetMagicResist(int.Parse(GameObject.Find("PMR").GetComponent<TMP_InputField>().text));
            IPlayer.SetIsMagical(int.Parse(GameObject.Find("PMagical").GetComponent<TMP_InputField>().text));
        IPlayer.SetIsMelee(GameObject.Find("PMelee").GetComponent<Toggle>().isOn);


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
        GameObject NewPlayer = Instantiate(EnemyPrefab, EnemySpawn.transform.position, Quaternion.identity);
            var IPlayer = NewPlayer.GetComponent<Attack_Manager>();
            IPlayer.SetHealth(int.Parse(GameObject.Find("EHealth").GetComponent<TMP_InputField>().text));
            IPlayer.SetAttackDamage(int.Parse(GameObject.Find("EAtkSpeed").GetComponent<TMP_InputField>().text));
            IPlayer.SetAttackSpeed(float.Parse(GameObject.Find("EADmg").GetComponent<TMP_InputField>().text));
            IPlayer.SetBulletSpeed(int.Parse(GameObject.Find("EBltSpeed").GetComponent<TMP_InputField>().text));
            IPlayer.SetArmor(int.Parse(GameObject.Find("EArmor").GetComponent<TMP_InputField>().text));
            IPlayer.SetMagicResist(int.Parse(GameObject.Find("EMR").GetComponent<TMP_InputField>().text));
            IPlayer.SetIsMagical(int.Parse(GameObject.Find("EMagical").GetComponent<TMP_InputField>().text));
        IPlayer.SetIsMelee(GameObject.Find("EMelee").GetComponent<Toggle>().isOn);


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
