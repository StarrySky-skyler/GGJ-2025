using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDeath : MonoBehaviour
{
    // �������ݵ�Rigidbody 2D����������������
    private Rigidbody2D rb;

    // �ŷ�Prefab����
    public GameObject envelopePrefab;

    void Start()
    {
        // ����Ϸ��ʼʱ��ȡRigidbody 2D���
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ��������Ƿ��������ϰ��﷢����ײ
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            // �����ײ��������ϰ��ִ����������
            Die();
        }
    }

    void Die()
    {
        // �����������������Ч�������粥����������������������Ч��
        // ���磬����һ���򵥵�����Ч����ģ����������
        ParticleSystem ps = GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }

        // ����������Ч����Ҫ��ǰ����Ŀ�е�����Ч�ļ���������һ��AudioSource�����
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        // �����ŷ�
        Instantiate(envelopePrefab, transform.position, Quaternion.identity);

        // ��������GameObject��ʹ��ӳ�������ʧ
        Destroy(gameObject);
    }
}