using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyMark;
    private Vector3 enemyMarkPos;

    private GameObject wallObj;
    private Wall wall;

    private PlayerBullet bullet;

    private Vector3 pos;

    public Vector3 backRota;

    public float startSpeed;

    public float backSpeed;

    private float speed;

    public float hp;

    public bool isNull;

    public int level;

    public float level1Pos;
    public float level2Pos;
    public float level3Pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        hp = 2;

        level = 0;

        enemyMarkPos = new Vector3(transform.position.x, 5 - (transform.localScale.y / 2), transform.position.z);
        Instantiate(enemyMark, enemyMarkPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        wallObj = GameObject.Find("Wall(Clone)");

        if (wallObj != null)
        {
            wall = wallObj.GetComponent<Wall>();
        }

        if (hp == 2)
        {
            speed = startSpeed;
        }
        else if (hp == 1)
        {
            speed = backSpeed;
            transform.eulerAngles = backRota;
        }

        pos = transform.position;

        pos.y += speed;

        transform.position = pos;

        if (pos.y >= 15 || pos.y <= -7)
        {
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
            bullet = collision.gameObject.GetComponent<PlayerBullet>();

            if (bullet.transform.position.y < 5 - (bullet.transform.localScale.y / 2))
            {
                hp--;
                Destroy(collision.gameObject);

                if (transform.position.y > level1Pos)
                {
                    level = 1;
                }
                else if (transform.position.y > level2Pos)
                {
                    level = 2;
                }
                else if (transform.position.y > level3Pos)
                {
                    level = 3;
                }
            }
        }

        //if(collision.tag == "Wall")
        //{
        //    if(hp <= 1)
        //    {
        //        wall.isPush = true;
        //        Destroy(gameObject);
        //    }
        //}
    }
}
