using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSplitter : MonoBehaviour
{
    public GameObject bubblePrefab; // �����ݵ�Ԥ����
    public void GenerateBubble()
    {
        // �����ݵ�ǰλ������������
        Instantiate(bubblePrefab, transform.position, Quaternion.identity);
    }

}