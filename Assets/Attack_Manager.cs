using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Manager : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    private float AttackSpeed;
    private int AttackDamage;
    private int BulletSpeed;
    private int Health;
    private int Armor;
    private int MagicResist;
    private bool isMagical;
    private GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", Time.deltaTime, AttackSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack()
    {
        if(gameObject.tag == "Player")
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        else
        {
            Enemy = GameObject.FindGameObjectWithTag("Player");
        }
        GameObject newBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Bullet>().SetEnemy(Enemy);
        newBullet.GetComponent<Bullet>().SetSpeed(BulletSpeed);

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
    public bool GetIsMagical()
    {
        return isMagical;
    }
    public void SetIsMagical(bool isM)
    {
        isMagical = isM;
    }
}
