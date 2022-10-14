using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject wallObj;

    private Wall wall;

    private Vector3 pos;

    public float startSpeed;

    private float speed;

    public float hp;

    public bool isNull;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        hp = 2;
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
            speed = startSpeed * -1;
        }

        pos = transform.position;

        pos.y += speed;

        transform.position = pos;

        if (pos.y >= 15 || pos.y <= -7)
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            hp--;
            Destroy(collision.gameObject);
        }

        if(collision.tag == "Wall")
        {
            if(hp <= 1)
            {
                wall.isPush = true;
                Destroy(gameObject);
            }
        }
    }
}
