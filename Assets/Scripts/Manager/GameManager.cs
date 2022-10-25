using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isClear;

    public bool isGameOver;

    public float timer;
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
        }
    }
    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }
}
