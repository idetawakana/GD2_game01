using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TitleText : MonoBehaviour
{
    private Wall wall;
    public Vector3 pos;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GameObject wallObj = GameObject.Find("Wall");
        wall = wallObj.GetComponent<Wall>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        if (wall.isPush == true)
        {
            pos.y += wall.pushSpeed * speed;
            transform.position = pos;
        }
    }
}
