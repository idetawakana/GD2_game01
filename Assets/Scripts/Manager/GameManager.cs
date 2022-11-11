using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isClear;

    public bool isGameOver;

    public float timer;

    public float finishTimer;

    public string nextScene;

    public int sceneNum;
    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneReset();
        }

        if(isClear == false)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                isGameOver = true;
            }
        }else if(isClear == true)
        {
            if (finishTimer > 0)
            {
                finishTimer -= Time.deltaTime;
            }else if(finishTimer <= 0)
            {
                ChangeScene(nextScene);
            }
        }

        if(isGameOver == true)
        {
            if(sceneNum == 0)
            {
                if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    sceneNum = 1;
                }
            }else if(sceneNum == 1)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    sceneNum = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(sceneNum == 0)
                {
                    ChangeScene("Title");
                }else if(sceneNum == 1)
                {
                    SceneReset();
                }
            }
        }
    }

    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }
}
