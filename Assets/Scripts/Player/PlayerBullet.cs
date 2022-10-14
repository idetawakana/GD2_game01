using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Vector3 pos;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        pos.y += speed;
        transform.position = pos;

        if (pos.y >= 10)
        {
            Destroy(gameObject);
        }
    }
}
