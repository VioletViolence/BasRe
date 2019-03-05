using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    GameObject AttackTarget;
    GameObject Axe;
    // Update is called once per frame

    private void Start()
    {
        Axe = GameObject.Find("axe1");
    }
    void Update()
    {
        AttackTarget = GameObject.FindGameObjectWithTag("Player");
        if (AttackTarget != null)
        {
            Charge(AttackTarget);
        }
        else
        {
            this.gameObject.GetComponent<Animator>().Play("Stand_Idle");
        }
    }

    void Charge(GameObject target)
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) > 1.7f)
        {

            this.gameObject.GetComponent<Animator>().Play("Run");
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 0.03f);
        }
        else
        {
            if (Axe != null)
            {
                if (Axe.activeSelf)
                {
                    Axe.SetActive(false);
                }
            }
            this.gameObject.GetComponent<Animator>().speed = this.gameObject.GetComponent<Attack_Manager>().GetAttackSpeed();
            this.gameObject.GetComponent<Animator>().Play("RightPunch");
        }
    }

    public void DamageMeleeEvent()
    {
        var Attacker = gameObject.GetComponent<Attack_Manager>();
        AttackTarget.GetComponent<Attack_Manager>().Hit(Attacker.GetAttackDamage(), Attacker.GetIsMagical());
    }
}
