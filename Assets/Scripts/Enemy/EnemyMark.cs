using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMark : MonoBehaviour
{
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();

            if(enemy.hp == 2)
            {
                Destroy(gameObject);
            }
        }
    }
}
