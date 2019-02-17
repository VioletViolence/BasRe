using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody RigThis;
    public float Speed;
    public int Damage;
    [SerializeField] GameObject Enemy;

    public void SetEnemy(GameObject E)
    {
        Enemy = E;
    }

    public void SetSpeed(int S)
    {
        Speed = S;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
            // Debug.Log("Enemy is: " + Enemy.name + ". At the position: "+ Enemy.transform.position + " And I am at this position: " + transform.position);
            if (Enemy == null || transform.position == Enemy.transform.position)
            {
                Enemy.GetComponent<Target>().SendMessage("Hit", Damage);
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Enemy.transform.position, Speed / 20);
            }
        }
        catch(NullReferenceException e)
        {
            Destroy(gameObject);
        }
      
    }

    
}
