using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    public string stage1;
    public string stage2;
    public string stage3;

    public int stage;

    //public Text stageText;
    // Start is called before the first frame update
    void Start()
    {
        stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(stage == 3)
            {
                stage = 1;
            }
            else
            {
                stage++;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (stage == 1)
            {
                stage = 3;
            }
            else
            {
                stage--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(stage == 1)
            {
                ChangeScene(stage1);
            }
            else if (stage == 2)
            {
                ChangeScene(stage2);
            }
            else if (stage == 3)
            {
                ChangeScene(stage3);
            }
        }

        //stageText.text = "nextstage " + stage;
    }

    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}
