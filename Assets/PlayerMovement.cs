using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 角色移动速度
    public float jumpForce = 10f; // 跳跃力度

    private Rigidbody2D rb;
    private bool isGrounded = false; // 是否在地面上

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 检测是否在地面上
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position, 0.1f, LayerMask.GetMask("Ground"));
    }

    void FixedUpdate()
    {
        // 获取水平输入
        float moveInput = Input.GetAxis("Horizontal");

        // 应用水平力
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 跳跃
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
