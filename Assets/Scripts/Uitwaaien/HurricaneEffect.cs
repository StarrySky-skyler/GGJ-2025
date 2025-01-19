using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurricaneEffect : MonoBehaviour
{
    public float forceStrength = 10f; //飓风作用力强度
    public Vector2 forceDirection; //飓风作用力方向

    private void FixedUpdate()
    {
        //获取场景中所有带有Rigidbody2D组件的泡泡
        Rigidbody2D[] bubbles = FindObjectsOfType<Rigidbody2D>();

        foreach (Rigidbody2D bubble in bubbles)
        {
            //计算飓风作用力
            Vector2 force = -forceDirection.normalized * forceStrength;

            //将飓风作用力应用到泡泡上，使其反向移动
            bubble.AddForce(force, ForceMode2D.Force);
        }
    }
}
