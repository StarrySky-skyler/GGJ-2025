using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSplitter : MonoBehaviour
{
    public GameObject bubblePrefab; // 新泡泡的预制体
    public void GenerateBubble()
    {
        // 在泡泡当前位置生成新泡泡
        Instantiate(bubblePrefab, transform.position, Quaternion.identity);
    }

}