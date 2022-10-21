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

    // Start is called before the first frame update
    void Start()
    {
        csvFile = Resources.Load("test") as TextAsset; // Resouces下のCSV読み込み
        reader = new StringReader(csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        //while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        //{        
        //    //StartCoroutine(DelayCoroutine());

        //    string line = reader.ReadLine(); // 一行ずつ読み込み
        //    csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        //}

        StartCoroutine(EnemyPos());

        //listCount = csvDatas.Count;

        //Debug.Log(listCount);
    }

    private IEnumerator EnemyPos()
    {
        while (reader.Peek() != -1)
        {
            line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加

            if (csvDatas[0][0] == "a")
            {
                Debug.Log(csvDatas[0][1]);
            }

            if (csvDatas[0][0] == "b")
            {
                Debug.Log(csvDatas[0][2]);
            }

            if (csvDatas[0][0] == "c")
            {
                Debug.Log(csvDatas[0][3]);
            }

            if (csvDatas[0][0] == "WAIT")
            {
                // 3秒間待つ
                yield return new WaitForSeconds(3);
            }

            csvDatas.Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
