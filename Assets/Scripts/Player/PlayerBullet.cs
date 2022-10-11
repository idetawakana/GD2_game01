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

        //íeÇ™îÚÇÒÇ≈Ç≠èàóù
        pos.y += speed;
        transform.position = pos;
    }
}
