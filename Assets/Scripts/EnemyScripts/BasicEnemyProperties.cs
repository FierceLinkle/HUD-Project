using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyProperties : MonoBehaviour
{
    public BasicEnemy BasicEnemy;

    public GameObject Enemy;

    public float EnemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Flame Hit Box")
        {
            EnemyHealth -= 40;
        }
        else if(col.gameObject.tag == "Thunder Hit Box")
        {
            EnemyHealth -= 30;
        }
        else if (col.gameObject.tag == "Ice Hit Box")
        {
            EnemyHealth -= 20;
        }
        else if (col.gameObject.tag == "Swordhitbox")
        {
            EnemyHealth -= 30;
            Debug.Log("Sword hit!");
        }
    }

    void Death()
    {
        if(EnemyHealth <= 0)
        {
            BasicEnemy.EnemyCounter--;
            Enemy.SetActive(false);
        }
    }
}
