using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yazirusi : MonoBehaviour
{
    public StageSelectManager stageSelectManager;
    public int stage;
    // Start is called before the first frame update
    void Start()
    {
        GameObject selectManager = GameObject.Find("StageSelectManager");
        stageSelectManager = selectManager.GetComponent<StageSelectManager>();

        stage = stageSelectManager.stage;
    }

    // Update is called once per frame
    void Update()
    {
        stage = stageSelectManager.stage;
        if(stage == 1)
        {
            transform.position = new Vector3(86, 593, 0);
        }
        else if (stage == 2)
        {
            transform.position = new Vector3(86, 368, 0);
        }
        else if (stage == 3)
        {
            transform.position = new Vector3(86, 140, 0);
        }
    }
}
