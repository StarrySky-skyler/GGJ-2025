using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurricaneEffect : MonoBehaviour
{
    public float forceStrength = 10f; //쫷�������ǿ��
    public Vector2 forceDirection; //쫷�����������

    private void FixedUpdate()
    {
        //��ȡ���������д���Rigidbody2D���������
        Rigidbody2D[] bubbles = FindObjectsOfType<Rigidbody2D>();

        foreach (Rigidbody2D bubble in bubbles)
        {
            //����쫷�������
            Vector2 force = -forceDirection.normalized * forceStrength;

            //��쫷�������Ӧ�õ������ϣ�ʹ�䷴���ƶ�
            bubble.AddForce(force, ForceMode2D.Force);
        }
    }
}
