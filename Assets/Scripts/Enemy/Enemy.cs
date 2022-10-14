using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 pos;

    public float startSpeed;

    private float speed;

    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        hp = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp == 2)
        {
            speed = startSpeed;
        }else if(hp == 1)
        {
            speed = startSpeed * -1;
        }

        pos = transform.position;

        pos.y += speed;

        transform.position = pos;

        if(pos.y >= 10)
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
    }
}
