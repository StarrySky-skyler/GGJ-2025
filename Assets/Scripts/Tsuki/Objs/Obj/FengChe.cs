// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 22:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Tsuki.Objs
{
    public class FengChe : AutoDestoryObj
    {
        public float speedIncrease = 5f;  // �����ٶ����ӵ���
        private bool _triggered;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !_triggered)
            {
                _triggered = true;
                Rigidbody2D bubbleRigidbody = other.GetComponent<Rigidbody2D>();
                if (bubbleRigidbody != null)
                {
                    bubbleRigidbody.velocity += Vector2.right * speedIncrease;  // �������ݵ��ٶ�
                }
                Destroy(gameObject);  // ���ٷ糵����
            }
        }
    }
}
