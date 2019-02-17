using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] int Health;
    [SerializeField] GameObject DeathEffect;
    private bool isDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Hit(int dmg)
    {
      //  Debug.Log("I got hit for " + dmg + " damage and now have " + Health + (" health."));
        Health = Health - dmg;
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
            Destroy(gameObject);
        }
    }
}
