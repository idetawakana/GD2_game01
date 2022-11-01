using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScale : MonoBehaviour
{
    private Wall wall;
    private GameObject wallObj;

    public Vector3 scale;

    public Vector3 wallPos;

    public float addScale;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject wallObj = GameObject.Find("Wall(Clone)");
        if (wallObj != null)
        {
            wall = wallObj.GetComponent<Wall>();
            wallPos = transform.localPosition;
        }

        if(wallObj != null){
            if(wallPos.y >= 3.75)
            {
                
            }
        }
    }
}
