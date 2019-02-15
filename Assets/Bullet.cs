using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody RigThis;
    private GameObject Enemy;
    private int Speed;

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
        RigThis.velocity = Enemy.transform.position * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
