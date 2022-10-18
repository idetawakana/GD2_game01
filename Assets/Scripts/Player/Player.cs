using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Vector3 pos;

    private Vector3 scale;

    public float hp;

    public float speed;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (pos.x >= -3.75 + (scale.x / 2) + speed)
            {
                pos.x -= speed;
                transform.position = pos;
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (pos.x <= 3.75 - (scale.x / 2) - speed)
            {
                pos.x += speed;
                transform.position = pos;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, pos, Quaternion.identity);
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            hp--;
            Destroy(collision.gameObject);
        }

        if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
