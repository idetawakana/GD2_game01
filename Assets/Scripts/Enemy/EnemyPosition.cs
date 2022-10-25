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

    private Vector3 pos;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        csvFile = Resources.Load("test") as TextAsset; // Resouces����CSV�ǂݍ���
        reader = new StringReader(csvFile.text);

        StartCoroutine(EnemyPos());
    }

    private IEnumerator EnemyPos()
    {
        while (reader.Peek() != -1)
        {
            line = reader.ReadLine(); // ��s���ǂݍ���
            csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�

            if (csvDatas[0][0] == "POP")
            {
                //Debug.Log(float.Parse(csvDatas[0][1]));
                pos = new Vector3(float.Parse(csvDatas[0][1]), float.Parse(csvDatas[0][2]), 0);

                Instantiate(enemy, pos, Quaternion.identity);
            }

            if (csvDatas[0][0] == "WAIT")
            {
                // �҂�(�b)
                yield return new WaitForSeconds(float.Parse(csvDatas[0][1]));
            }

            if (csvDatas[0][0] == "f")
            {
                //�҂�(�t���[��)
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
