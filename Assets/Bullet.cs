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

    public GameObject GetEnemy()
    {
        return Enemy;
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
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Enemy = FindClosestEnemy(Enemies);
            //Debug.Log("Enemy is: " + Enemy.name + ". At the position: "+ Enemy.transform.position + " And I am at this position: " + transform.position);
            if (Enemy == null || transform.position == Enemy.transform.position)
            {
                Enemy.GetComponent<Attack_Manager>().SendMessage("Hit", Damage);
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Enemy.transform.position, Speed/10);
            }
        }
        catch(NullReferenceException e)
        {
            Destroy(gameObject);
        }
      
    }
    public GameObject FindClosestEnemy(GameObject[] Enemies)
    {

        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject dork in Enemies)
        {
            Vector3 diff = dork.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = dork;
                distance = curDistance;
            }
        }
        return closest;
    }


}
