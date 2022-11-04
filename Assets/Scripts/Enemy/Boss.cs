using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameManager gameManager;

    private Enemy enemy;

    private Wall wall;
    private GameObject wallObj;
    private Vector3 wallPos;
    private Vector3 wallScale;

    private Vector3 pos;

    private Vector3 scale;

    private Vector3 startScale;

    public float hp;

    public float speed;

    public float wallDamage1;
    public float wallDamage2;
    public float wallDamage3;

    public float enemyDamage1;
    public float enemyDamage2;
    public float enemyDamage3;

    public float bulletDamage;

    public bool isCrush;

    public bool isReturn;

    public float addScaleY;
    // Start is called before the first frame update
    void Start()
    {
        GameObject managerObj = GameObject.Find("GameManager");
        gameManager = managerObj.GetComponent<GameManager>();

        pos = transform.position;
        scale = transform.localScale;
        startScale = transform.localScale;

        isCrush = false;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        pos.x += speed;

        transform.position = pos;

        if (isCrush == true)
        {
            if (wall != null)
            {
                scale = ScaleChange(wall);
                transform.localScale = scale;
                pos.y = 5 - (scale.y / 2);
                transform.position = pos;
            }

            if (wall.isPush == false)
            {
                isCrush = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            isReturn = true;
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            //isReturn = false;
        }

        if(isReturn == true)
        {
            if (scale.y <= 1 - addScaleY)
            {
                scale.y += addScaleY;
                scale.x = 1 / scale.y;
            }
            else
            {
                scale.y = 1.0f;
                scale.x = 1.0f;
                isReturn = false;
            }

            transform.localScale = scale;
            pos.y = 5 - (scale.y / 2);
            transform.position = pos;

            if(isCrush == false)
            {
                if(wall != null)
                {
                    wallPos = wall.transform.position;
                    wallScale = wall.transform.localScale;

                    if (pos.y - (scale.y / 2) < wallPos.y + (wallScale.y / 2))
                    {
                        wallPos.y = pos.y - (scale.y / 2) - (wallScale.y / 2);
                        wall.transform.position = wallPos;
                    }
                }
            }
        }

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

    private Vector3 ScaleChange(Wall wall)
    {
        Vector3 scale = transform.localScale;
        Vector3 wallPos = wall.transform.position;
        float addScaleY = (wallPos.y + wall.transform.localScale.y / 2) - (pos.y - scale.y / 2);
        scale.y -= addScaleY;
        scale.x = 1 / scale.y;
        return scale;
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


            wallObj = collision.gameObject;
            wall = wallObj.GetComponent<Wall>();

            if (wall.isPush == true)
            {
                isCrush = true;
            }

            //scale = ScaleChange(collision);
            //transform.localScale = scale;
            //pos.y = 5 - (scale.y / 2);
            //transform.position = pos;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            //scale = ScaleChange(collision);
            //transform.localScale = scale;
            //pos.y = 5 - (scale.y / 2);
            //transform.position = pos;
        }
    }

}
