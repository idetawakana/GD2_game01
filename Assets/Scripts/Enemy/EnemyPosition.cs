using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Analytics;

public class EnemyPosition : MonoBehaviour
{
    TextAsset csvFile; // CSVファイル
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    private StringReader reader;

    private String line;

    private int listCount;

    private Vector3 pos;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        csvFile = Resources.Load("test") as TextAsset; // Resouces下のCSV読み込み
        reader = new StringReader(csvFile.text);

        StartCoroutine(EnemyPos());
    }

    private IEnumerator EnemyPos()
    {
        while (reader.Peek() != -1)
        {
            line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加

            if (csvDatas[0][0] == "POP")
            {
                //Debug.Log(float.Parse(csvDatas[0][1]));
                pos = new Vector3(float.Parse(csvDatas[0][1]), float.Parse(csvDatas[0][2]), 0);

                Instantiate(enemy, pos, Quaternion.identity);
            }

            if (csvDatas[0][0] == "WAIT")
            {
                // 待つ(秒)
                yield return new WaitForSeconds(float.Parse(csvDatas[0][1]));
            }

            if (csvDatas[0][0] == "f")
            {
                //待つ(フレーム)
                for (var i = 0; i < float.Parse(csvDatas[0][1]); i++)
                {
                    yield return null;
                }
            }

            csvDatas.Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
