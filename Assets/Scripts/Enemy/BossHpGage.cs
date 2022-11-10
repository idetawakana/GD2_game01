using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpGage : MonoBehaviour
{
    private Boss boss;
    private float hp;
    private float maxHp;

    private float scaleX;

    public Color color;

    public Color maxColor;
    public Color halfColor;
    public Color fewColor;

    public RawImage rawImage;
    // Start is called before the first frame update
    void Start()
    {
        GameObject bossObj = GameObject.Find("Boss");
        if (bossObj != null)
        {
            boss = bossObj.GetComponent<Boss>();
            hp = boss.hp;
            maxHp = boss.maxHp;
        }

        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        hp = boss.hp;

        scaleX = hp * 7.2f / maxHp;
        transform.localScale = new Vector3(scaleX, 0.5f, 1);

        if(hp/maxHp >= 0.5)
        {
            color = maxColor;
        }else if(hp / maxHp >= 0.2)
        {
            color = halfColor;
        }else if(hp / maxHp >= 0)
        {
            color = fewColor;
        }

        //color = new Vector4(1, 1, 1, 1);

        rawImage.color = color;
    }
}
