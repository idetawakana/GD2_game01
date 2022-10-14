using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    private Vector3 pos;

    public GameObject wall;

    public bool isDestroy;

    private float timer;

    public float startTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        pos = new Vector3(0, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDestroy == true && timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            Instantiate(wall, pos, Quaternion.identity);
            isDestroy = false;
            timer = startTimer;
        }
    }
}
