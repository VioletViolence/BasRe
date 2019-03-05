using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Attack_Manager : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject AttackPoint;
    [SerializeField] GameObject DeathEffect;
    private bool isDestroyed = false;
    private float AttackSpeed = 1f;
    private int AttackDamage = 100;
    private int BulletSpeed = 10;
    [SerializeField] private int Health = 3000;
    private int Armor = 20;
    private int MagicResist = 20;
    private int isMagical = 20;
    private bool isMelee = false;

    GameObject playerScore;
    GameObject enemyScore;
    // Start is called before the first frame update
    void Start()
    {
        if(!isMelee)
        {
            DoAttack();
        }
        playerScore = GameObject.Find("PlayerScore");
        enemyScore = GameObject.Find("EnemyScore");
    }

    public void DoAttack()
    {
        if (!isMelee)
        {
            InvokeRepeating("Attack", Time.deltaTime, 1 / AttackSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack()
    {
        GameObject newBullet = Instantiate(Bullet, AttackPoint.transform.position, Quaternion.identity );
        newBullet.transform.parent = gameObject.transform;
        newBullet.GetComponent<Bullet>().Speed = AttackSpeed;
        newBullet.GetComponent<Bullet>().Damage = AttackDamage;
        newBullet.GetComponent<Bullet>().MagicalPercent = isMagical;
    }
    public void Hit(int dmg, int magPercent)
    {
        //  Debug.Log("I got hit for " + dmg + " damage and now have " + Health + (" health."));
        var mgDmg = dmg * magPercent;
        var phDmg = dmg - mgDmg;
        Health = Health - (int)((mgDmg * (1 - (MagicResist * 0.01f))) + (phDmg * (1 - (Armor * 0.01f))));
        if (Health <= 0 && isDestroyed == false)
        {
            GameObject[] Bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject item in Bullets)
            {
                GameObject itemTarget = item.GetComponent<Bullet>().GetEnemy();
                if (itemTarget == gameObject)
                {
                    Destroy(item);
                }
            }
            Instantiate(DeathEffect, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
            isDestroyed = true;
            
            if(this.tag == "Player")
            {
                var count = int.Parse(enemyScore.GetComponent<TMP_Text>().text) + 1;
                enemyScore.GetComponent<TMP_Text>().text = count.ToString();
            }
            else if (this.tag == "Enemy")
            {
                var count = int.Parse(playerScore.GetComponent<TMP_Text>().text) + 1;
                playerScore.GetComponent<TMP_Text>().text = count.ToString();
            }
            Destroy(gameObject);
        }
    }


    // Getters and Setters
    public float GetAttackSpeed()
    {
        return AttackSpeed;
    }
    public void SetAttackSpeed(float atk)
    {
        AttackSpeed = atk;
    }
    public int GetAttackDamage()
    {
        return AttackDamage;
    }
    public void SetAttackDamage(int dmg)
    {
        AttackDamage = dmg;
    }
    public int GetHealth ()
    {
        return Health;
    }
    public void SetHealth(int HP)
    {
        Health = HP;
    }
    public int GetBulletSpeed()
    {
        return BulletSpeed;
    }
    public void SetBulletSpeed(int bullSp)
    {
        AttackSpeed = bullSp;
    }
    public int GetArmor()
    {
        return Armor;
    }
    public void SetArmor(int arm)
    {
        Armor = arm;
    }
    public int GetMagicResist()
    {
        return MagicResist;
    }
    public void SetMagicResist(int magRes)
    {
        MagicResist = magRes
;
    }
    public int GetIsMagical()
    {
        return isMagical;
    }
    public void SetIsMagical(int isM)
    {
        isMagical = isM;
    }
    public void SetIsMelee(bool melee)
    {
        isMelee = melee;
    }
}
