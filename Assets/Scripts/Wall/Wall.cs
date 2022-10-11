using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Vector3 pos;

    public float speed;

    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        //‚¾‚ñ‚¾‚ñ—‚¿‚Ä‚­‚éˆ—
        pos.y -= speed;
        transform.position = pos;

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            hp--;
            Destroy(collision.gameObject);
        }
    }
}
