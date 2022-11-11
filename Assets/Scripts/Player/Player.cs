using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    private Vector3 pos;

    private Vector3 scale;

    public float hp;

    public float speed;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj != null)
        {
            gameManager = gameManagerObj.GetComponent<GameManager>();
        }

        pos = transform.position;

        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isClear == false && gameManager.isGameOver == false)
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
                gameManager.PlaySEBullet();
            }

            if (hp <= 0)
            {
                gameManager.isGameOver = true;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            hp--;
            Destroy(collision.gameObject);
            gameManager.PlaySEAttack();
        }

        if(collision.tag == "Wall")
        {
            gameManager.isGameOver = true;
            gameManager.PlaySEAttack();
            Destroy(gameObject);
        }
    }
}
