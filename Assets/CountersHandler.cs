using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountersHandler : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
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

            // Enemy stats
            private int EnemyHealthSetter;
            private int EnemyDmgSetter;
            private float EnemyAtkSpeedSetter;
            private int EnemyBltSpeedSetter;
            private int EnemyArmorSetter;
            private int EnemyMagResSetter;
            private int EnemyMagDmgPercentSetter;

            // Player stats
            private int PlayerHealthSetter;
            private int PlayerDmgSetter;
            private float PlayerAtkSpeedSetter;
            private int PlayerBltSpeedSetter;
            private int PlayerArmorSetter;
            private int PlayerMagResSetter;
            private int PlayerMagDmgPercentSetter;

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
        EnemySlider.value = EnemyHealth;
        EnemyHealthCounter.text = EnemySlider.value.ToString();
        PlayerSlider.value = PlayerHealth;
        PlayerHealthCounter.text = PlayerSlider.value.ToString();
    }

    public void SetPlayerStats()
    {
            EnemyHealthSetter = int.Parse(GameObject.Find("PHealth").GetComponent<TMP_InputField>().text);
            PlayerDmgSetter = int.Parse(GameObject.Find("PADmg").GetComponent<TMP_InputField>().text);
            PlayerAtkSpeedSetter = int.Parse(GameObject.Find("PAtkSpeed").GetComponent<TMP_InputField>().text);
            PlayerBltSpeedSetter = int.Parse(GameObject.Find("BltSpeed").GetComponent<TMP_InputField>().text);
            PlayerArmorSetter = int.Parse(GameObject.Find("PArmor").GetComponent<TMP_InputField>().text);
            PlayerMagResSetter = int.Parse(GameObject.Find("PMR").GetComponent<TMP_InputField>().text);
            PlayerMagDmgPercentSetter = int.Parse(GameObject.Find("PMagical").GetComponent<TMP_InputField>().text);
    }
    public void SetEnemyStats()
    {
        var Enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(Enemy != null)
        {
            SetExistingEnemyStats();
        }
        else if (Enemy == null)
        {
            Instantiate(EnemyPrefab, GameObject.Find("EnemyLaunchPoint").transform.position , Quaternion.identity);
        }
            
    }
    private void SetExistingEnemyStats()
    {
        EnemyHealthSetter = int.Parse(GameObject.Find("EHealth").GetComponent<TMP_InputField>().text);
        EnemyDmgSetter = int.Parse(GameObject.Find("EADmg").GetComponent<TMP_InputField>().text);
        EnemyAtkSpeedSetter = int.Parse(GameObject.Find("EAtkSpeed").GetComponent<TMP_InputField>().text);
        EnemyBltSpeedSetter = int.Parse(GameObject.Find("EBltSpeed").GetComponent<TMP_InputField>().text);
        EnemyArmorSetter = int.Parse(GameObject.Find("EArmor").GetComponent<TMP_InputField>().text);
        EnemyMagResSetter = int.Parse(GameObject.Find("EMR").GetComponent<TMP_InputField>().text);
        EnemyMagDmgPercentSetter = int.Parse(GameObject.Find("EMagical").GetComponent<TMP_InputField>().text);
    }
}
