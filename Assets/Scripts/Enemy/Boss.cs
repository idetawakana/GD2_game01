using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameManager gameManager;

    private Vector3 pos;

    public float hp;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GameObject managerObj = GameObject.Find("GameManager");
        gameManager = managerObj.GetComponent<GameManager>();

        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        pos.x += speed;

        transform.position = pos;

        if(pos.x <= -3.25 || pos.x >= 3.25)
        {
            speed *= -1;
        }

        if(hp <= 0)
        {
            gameManager.isClear = true;
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
