using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Analytics;

public class EnemyPosition : MonoBehaviour
{
    TextAsset csvFile; // CSV�t�@�C��
    List<string[]> csvDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g;

    private StringReader reader;

    private String line;

    private int listCount;

    // Start is called before the first frame update
    void Start()
    {
        csvFile = Resources.Load("test") as TextAsset; // Resouces����CSV�ǂݍ���
        reader = new StringReader(csvFile.text);

        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        //while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        //{        
        //    //StartCoroutine(DelayCoroutine());

        //    string line = reader.ReadLine(); // ��s���ǂݍ���
        //    csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
        //}

        StartCoroutine(EnemyPos());

        //listCount = csvDatas.Count;

        //Debug.Log(listCount);
    }

    private IEnumerator EnemyPos()
    {
        while (reader.Peek() != -1)
        {
            line = reader.ReadLine(); // ��s���ǂݍ���
            csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�

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
                // 3�b�ԑ҂�
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
