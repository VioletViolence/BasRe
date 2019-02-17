using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] int Health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health<= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Hit(int dmg)
    {
        Debug.Log("I got hit for " + dmg + " damage and now have " + Health + (" health."));
        Health = Health - dmg;
    }
}
