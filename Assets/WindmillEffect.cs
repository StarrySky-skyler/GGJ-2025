using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillEffect : MonoBehaviour
{
    public float speedIncrease = 5f;  // �����ٶ����ӵ���

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bubble"))  // �ж���ײ�Ķ����Ƿ�Ϊ����
        {
            Rigidbody2D bubbleRigidbody = collision.GetComponent<Rigidbody2D>();
            if (bubbleRigidbody != null)
            {
                bubbleRigidbody.velocity += Vector2.right * speedIncrease;  // �������ݵ��ٶ�
            }
            Destroy(gameObject);  // ���ٷ糵����
        }
    }
}
