using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player;

    public bool isClear;

    public bool isGameOver;

    public float timer;

    public float finishTimer;

    public string nextScene;

    public int sceneNum;

    public Text timeText;
    public Text playerHp;

    public GameObject gameOverText;
    public GameObject clearText;
    public GameObject retryText;
    public GameObject titleText;
    public GameObject retryImage;
    public GameObject titleImage;
    public GameObject yazirusi0;
    public GameObject yazirusi1;

    public AudioSource bulletSE;
    public AudioSource attackSE;
    public AudioSource clearSE;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();

        isClear = false;
        isGameOver = false;

        gameOverText.SetActive(false);
        clearText.SetActive(false);
        retryText.SetActive(false);
        titleText.SetActive(false);
        retryImage.SetActive(false);
        titleImage.SetActive(false);
        yazirusi0.SetActive(false);
        yazirusi1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneReset();
        }

        if(isClear == false && isGameOver == false)
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
                //PlaySEClear();
                clearText.SetActive(true);
                finishTimer -= Time.deltaTime;
            }else if(finishTimer <= 0)
            {
                ChangeScene(nextScene);
            }
        }

        if(isGameOver == true)
        {
            gameOverText.SetActive(true);
            retryImage.SetActive(true);
            retryText.SetActive(true);
            titleImage.SetActive(true);
            titleText.SetActive(true);

            if(sceneNum == 0)
            {
                yazirusi0.SetActive(true);
                yazirusi1.SetActive(false);

                if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    sceneNum = 1;
                    PlaySEBullet();
                }
            }else if(sceneNum == 1)
            {
                yazirusi0.SetActive(false);
                yazirusi1.SetActive(true);

                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    sceneNum = 0;
                    PlaySEBullet();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlaySEAttack();
                if(sceneNum == 1)
                {
                    ChangeScene("Title");
                }else if(sceneNum == 0)
                {
                    SceneReset();
                }
            }
        }

        timeText.text = "" + (int)timer;
        playerHp.text = "HP " + player.hp + "/5";
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

    public void PlaySEBullet()
    {
        bulletSE.Play();
    }

    public void PlaySEAttack()
    {
        attackSE.Play();
    }

    public void PlaySEClear()
    {
        clearSE.Play();
    }
}
