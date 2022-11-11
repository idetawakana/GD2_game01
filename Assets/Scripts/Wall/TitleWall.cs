using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TitleWall : MonoBehaviour
{
    private WallSpawn wallSpawn;

    private TitleEnemy enemy;

    private Boss boss;

    private TitleManager titleManager;

    public Vector3 bossPos;

    private Vector3 pos;

    public float speed;

    public float hp;

    public bool isPush;

    private float pushTimer;
    public float pushTimer1;
    public float pushTimer2;
    public float pushTimer3;

    public float startPushTimer;

    public int level;

    public bool getLevel;

    public float pushSpeed;
    public float pushSpeed1;
    public float pushSpeed2;
    public float pushSpeed3;

    public float pushNum;

    public bool isTitle;
    // Start is called before the first frame update
    void Start()
    {
        GameObject titleManagerObj = GameObject.Find("TitleManager");
        titleManager = titleManagerObj.GetComponent<TitleManager>();

        pos = transform.position;

        isPush = false;

        pushTimer = startPushTimer;

        getLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPush == false)
        {
        }
        else
        {
            if (getLevel == false)
            {
                if (level == 1)
                {
                    pushTimer = pushTimer1;
                    pushSpeed = pushSpeed1;
                }
                else if (level == 2)
                {
                    pushTimer = pushTimer2;
                    pushSpeed = pushSpeed2;
                }
                else if (level == 3)
                {
                    pushTimer = pushTimer3;
                    pushSpeed = pushSpeed3;
                }
                getLevel = true;
            }

            if (isTitle == true)
            {
                pos.y += pushSpeed;
                transform.position = pos;
            }
        }

        if (isTitle == false)
        {
            if (hp <= 0)
            {
                wallSpawn.isDestroy = true;
                Destroy(gameObject);
            }
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
            if (isTitle == false)
            {
                hp--;
            }
            Destroy(collision.gameObject);

        }

        if (collision.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<TitleEnemy>();

            if (enemy.hp <= 1)
            {
                isPush = true;
                Destroy(collision.gameObject);
                level = enemy.level;
                titleManager.PlaySEAttack();
            }
        }
    }
}