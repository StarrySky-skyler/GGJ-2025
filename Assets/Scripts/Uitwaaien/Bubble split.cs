using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public GameObject bubblePrefab; // �����ݵ�Ԥ����
    public float fallSpeed = 5.0f; // �����ٶ�
    public float jumpSpeed = 10.0f; // ��Ծ�ٶ�
    private Rigidbody2D rb;
    private bool isGrounded = false; // �Ƿ��ڵ�����
    private GameObject generatedBubble; // ���ɵ������ݵ�����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ��������
        if (isGrounded)
        {
            rb.velocity = new Vector2(0, -fallSpeed);
        }

        // �����Ѱ�������
        if (Input.GetKeyDown(KeyCode.F))
        {
            SplitBubble();
        }

        // �����Ծ��������
        if (Input.GetKeyDown(KeyCode.Space) && generatedBubble != null)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        //此处可根据需要添加其他泡泡的移动或控制逻辑
    }

    // ����������
    public void SplitBubble()
    {
        // ��ȡԭ���ݵĳߴ�
        float bubbleSize = transform.localScale.y;

        // ��ԭ�������·����������ݣ�������ԭ����
        Vector3 spawnPosition = transform.position + new Vector3(0, -bubbleSize, 0);
        generatedBubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);

        // ���������ݵ������ٶ�
        Rigidbody2D generatedRb = generatedBubble.GetComponent<Rigidbody2D>();
        generatedRb.velocity = new Vector2(0, -fallSpeed);

        // ȷ������������ײ��
        if (!generatedBubble.GetComponent<Collider2D>())
        {
            generatedBubble.AddComponent<BoxCollider2D>();
        }
    }

    // ��Ծ����
    public void Jump()
    {
        // ���������ݣ�ʹ������˶�
        if (generatedBubble != null)
        {
            generatedBubble.transform.parent = null;
            generatedBubble = null; // ��������
        }

        // ��ȡ������ķ���
        float horizontal = Input.GetAxis("Horizontal");

        // ��ԭ����һ�������ϵĳ��ٶ�
        Vector2 jumpDirection = new Vector2(horizontal, jumpSpeed).normalized * jumpSpeed;
        rb.velocity = new Vector2(jumpDirection.x, jumpSpeed);

        // ��Ծ���ڵ�����
        isGrounded = false;
    }

    // ��ײ��⣬�ж��Ƿ��ڵ�����
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // ��������ǩΪ"Ground"
        {
            isGrounded = true;
        }
    }

    // �뿪�����ж�
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}