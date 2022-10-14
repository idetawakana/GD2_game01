using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameManager gameManager;

    private Enemy enemy;

    private GameObject enemyObj;

    private Vector3 pos;

    public float hp;

    public float speed;

    public float wallDamage;
    public float enemyDamage;
    public float bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        GameObject managerObj = GameObject.Find("GameManager");
        gameManager = managerObj.GetComponent<GameManager>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        pos = transform.position;

        pos.x += speed;

        transform.position = pos;

        if(pos.x <= -3.25 || pos.x >= 3.25)
        {
            speed *= -1;
        }

        if(hp <= 0)
        {
            gameManager.isClear = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            hp -= bulletDamage;
            Destroy(collision.gameObject);

            Debug.Log("bullet");
        }

        if(collision.tag == "Wall")
        {
            hp -= wallDamage;

            Debug.Log("wall");
        }

        if(collision.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy.hp <= 1)
            {
                hp -= enemyDamage;
                Destroy(collision.gameObject);

                Debug.Log("enemy");
            }
        }
    }
}
