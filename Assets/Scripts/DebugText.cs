using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    private Player player;
    public Text playerHp;

    private Boss boss;
    public Text bossHp;

    private Wall wall;
    private GameObject wallObj;
    public Text wallHp;

    private GameManager gameManager;
    public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();

        GameObject bossObj = GameObject.Find("Boss");
        boss = bossObj.GetComponent<Boss>();

        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject wallObj = GameObject.Find("Wall(Clone)");
        if (wallObj != null)
        {
            wall = wallObj.GetComponent<Wall>();
        }

        timer.text = "timer  " + (int)gameManager.timer;
        playerHp.text = "playerHP  " + player.hp + "/5";
        bossHp.text = "bossHP  " + boss.hp + "/100";
        if(wallObj != null)
        {
            wallHp.text = "wallHP  " + wall.hp + "/3";
        }
        else
        {
            wallHp.text = "‚©‚×‚±‚í‚ê‚½";
        }
    }
}
