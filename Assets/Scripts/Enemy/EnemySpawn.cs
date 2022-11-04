using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Vector3 enemyPos;

    public GameObject enemy;

    public GameObject enemy_;

    private Vector3 enemy_Pos;

    public float timer;

    public float startTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            enemyPos = new Vector3(Random.Range(-3.25f, 3.25f), 10, 0);

            //enemy_Pos = new Vector3()

            Instantiate(enemy, enemyPos, Quaternion.identity);

            //Instantiate(enemy_,)

            timer = startTimer;
        }
    }
}