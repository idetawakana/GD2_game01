using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private WallSpawn wallSpawn;

    private Enemy enemy;

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
    // Start is called before the first frame update
    void Start()
    {
        GameObject wallSpawnObj = GameObject.Find("WallSpawn");
        wallSpawn = wallSpawnObj.GetComponent<WallSpawn>();

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
        }
        else
        {
            if(pushTimer > 0)
            {
                pos = transform.position;

                if (pos.y - pushSpeed <= 4.2)
                {
                    pos.y += pushSpeed;
                    transform.position = pos;
                }

                pushTimer -= Time.deltaTime;
            }
            else if(pushTimer <= 0)
            {
                isPush = false;
                pushTimer = startPushTimer;
                level = 0;
            }
        }

        if(hp <= 0)
        {
            wallSpawn.isDestroy = true;
            Destroy(gameObject);
        }
    }

    public int GetLevel()
    {
        return level;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            hp--;
            Destroy(collision.gameObject);
        }

        if(collision.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy.hp <= 1)
            {
                isPush = true;
                Destroy(collision.gameObject);
                level = enemy.GetLevel();
            }
        }
    }
}
