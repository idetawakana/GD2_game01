using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameManager gameManager;

    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        GameObject managerObj = GameObject.Find("GameManager");
        gameManager = managerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
