using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Vector3 pos;

    public float speed;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed;
            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed;
            transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, pos, Quaternion.identity);
        }
    }
}
