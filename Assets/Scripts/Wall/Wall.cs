using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private WallSpawn wallSpawn;

    private Vector3 pos;

    public float speed;

    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        GameObject wallSpawnObj = GameObject.Find("WallSpawn");
        wallSpawn = wallSpawnObj.GetComponent<WallSpawn>();

        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        //ÇæÇÒÇæÇÒóéÇøÇƒÇ≠ÇÈèàóù
        pos.y -= speed;
        transform.position = pos;

        if(hp <= 0)
        {
            wallSpawn.isDestroy = true;
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
