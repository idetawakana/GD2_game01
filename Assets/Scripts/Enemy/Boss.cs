using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameManager gameManager;

    private Enemy enemy;

    private Wall wall;

    private Vector3 pos;

    private Vector3 scale;

    public float hp;

    public float speed;

    public float wallDamage1;
    public float wallDamage2;
    public float wallDamage3;

    public float enemyDamage1;
    public float enemyDamage2;
    public float enemyDamage3;

    public float bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        GameObject managerObj = GameObject.Find("GameManager");
        gameManager = managerObj.GetComponent<GameManager>();
        pos = transform.position;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        pos.x += speed;

        transform.position = pos;

        if (pos.x <= -3.75 + (scale.x / 2) || pos.x >= 3.75 - (scale.x / 2))
        {
            speed *= -1;
        }

        if (hp <= 0)
        {
            gameManager.isClear = true;
            Destroy(gameObject);
        }
    }

    private float Damage(float damage)
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            hp -= bulletDamage;
            Destroy(collision.gameObject);

            Debug.Log("bullet");
        }

        if (collision.tag == "Wall")
        {
            wall = collision.gameObject.GetComponent<Wall>();

            if (wall.level == 1)
            {
                hp -= wallDamage1;
                Debug.Log("wall1");
            }

            if (wall.level == 2)
            {
                hp -= wallDamage2;
                Debug.Log("wall2");
            }

            if (wall.level == 3)
            {
                hp -= wallDamage3;
                Debug.Log("wall3");
            }
        }

        if (collision.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy.hp <= 1)
            {
                if (enemy.level == 1)
                {
                    hp -= enemyDamage1;
                    Debug.Log("enemy1");
                }

                if (enemy.level == 2)
                {
                    hp -= enemyDamage2;
                    Debug.Log("enemy2");
                }

                if (enemy.level == 3)
                {
                    hp -= enemyDamage3;
                    Debug.Log("enemy3");
                }

                Destroy(collision.gameObject);
            }
        }
    }
}
