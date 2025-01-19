using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // ��ɫ�ƶ��ٶ�
    public float jumpForce = 10f; // ��Ծ����

    private Rigidbody2D rb;
    private bool isGrounded = false; // �Ƿ��ڵ�����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ����Ƿ��ڵ�����
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position, 0.1f, LayerMask.GetMask("Ground"));
    }

    void FixedUpdate()
    {
        // ��ȡˮƽ����
        float moveInput = Input.GetAxis("Horizontal");

        // Ӧ��ˮƽ��
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ��Ծ
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
