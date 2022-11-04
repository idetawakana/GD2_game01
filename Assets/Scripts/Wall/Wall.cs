using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private WallSpawn wallSpawn;

    private Enemy enemy;

    private Boss boss;

    public Vector3 bossPos;

    private Vector3 pos;

    public float speed;

    public float hp;

    public bool isPush;

    private float pushTimer;

    public float startPushTimer;

    public int level;

    public float pushSpeed;
    public float pushSpeed2;
    public float pushSpeed3;

    public float pushNum;
    // Start is called before the first frame update
    void Start()
    {
        GameObject wallSpawnObj = GameObject.Find("WallSpawn");
        wallSpawn = wallSpawnObj.GetComponent<WallSpawn>();

        GameObject bossObj = GameObject.Find("Boss");
        boss = bossObj.GetComponent<Boss>();

        pos = transform.position;

        isPush = false;

        pushTimer = startPushTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPush == false)
        {
            pos = transform.position;

            pos.y -= speed;
            transform.position = pos;

            bossPos = boss.transform.position;
        }
        else
        {
            if (pushTimer > 0)
            {
                pos = transform.position;

                //Ç«Ç±Ç‹Ç≈ï«ÇíµÇÀï‘ÇπÇÈÇÊÇ§Ç…Ç∑ÇÈÇ©ÇÕÇ±Ç±Ç≈ïœçX
                if (pos.y <= bossPos.y - (transform.localScale.y / pushNum))
                {
                    pos.y += pushSpeed;
                    transform.position = pos;
                }

                pushTimer -= Time.deltaTime;
            }
            else if (pushTimer <= 0)
            {
                isPush = false;
                pushTimer = startPushTimer;
                level = 0;
            }
        }

        if (hp <= 0)
        {
            wallSpawn.isDestroy = true;
            Destroy(gameObject);
        }
    }

    //public int GetLevel()
    //{
    //    return level;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            hp--;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy.hp <= 1)
            {
                isPush = true;
                Destroy(collision.gameObject);
                level = enemy.level;
            }
        }
    }
}