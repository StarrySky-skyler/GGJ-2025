using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillEffect : MonoBehaviour
{
    public float speedIncrease = 5f;  // 泡泡速度增加的量

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bubble"))  // 判断碰撞的对象是否为泡泡
        {
            Rigidbody2D bubbleRigidbody = collision.GetComponent<Rigidbody2D>();
            if (bubbleRigidbody != null)
            {
                bubbleRigidbody.velocity += Vector2.right * speedIncrease;  // 增加泡泡的速度
            }
            Destroy(gameObject);  // 销毁风车道具
        }
    }
}
