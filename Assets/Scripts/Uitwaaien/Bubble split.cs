using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public GameObject bubblePrefab; // 新泡泡的预制体
    public float fallSpeed = 5.0f; // 下落速度
    public float jumpSpeed = 10.0f; // 跳跃速度
    private Rigidbody2D rb;
    private bool isGrounded = false; // 是否在地面上
    private GameObject generatedBubble; // 生成的新泡泡的引用

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 自由下落
        if (isGrounded)
        {
            rb.velocity = new Vector2(0, -fallSpeed);
        }

        // 检测分裂按键输入
        if (Input.GetKeyDown(KeyCode.F))
        {
            SplitBubble();
        }

        // 检测跳跃按键输入
        if (Input.GetKeyDown(KeyCode.Space) && generatedBubble != null)
        {
            Jump();
        }
    }

    // 生成新泡泡
    public void SplitBubble()
    {
        // 获取原泡泡的尺寸
        float bubbleSize = transform.localScale.y;

        // 在原泡泡正下方生成新泡泡，紧挨着原泡泡
        Vector3 spawnPosition = transform.position + new Vector3(0, -bubbleSize, 0);
        generatedBubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);

        // 设置新泡泡的下落速度
        Rigidbody2D generatedRb = generatedBubble.GetComponent<Rigidbody2D>();
        generatedRb.velocity = new Vector2(0, -fallSpeed);

        // 确保新泡泡有碰撞器
        if (!generatedBubble.GetComponent<Collider2D>())
        {
            generatedBubble.AddComponent<BoxCollider2D>();
        }
    }

    // 跳跃方法
    public void Jump()
    {
        // 分离新泡泡，使其独立运动
        if (generatedBubble != null)
        {
            generatedBubble.transform.parent = null;
            generatedBubble = null; // 重置引用
        }

        // 获取方向键的方向
        float horizontal = Input.GetAxis("Horizontal");

        // 给原泡泡一个方向上的初速度
        Vector2 jumpDirection = new Vector2(horizontal, jumpSpeed).normalized * jumpSpeed;
        rb.velocity = new Vector2(jumpDirection.x, jumpSpeed);

        // 跳跃后不在地面上
        isGrounded = false;
    }

    // 碰撞检测，判断是否在地面上
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 假设地面标签为"Ground"
        {
            isGrounded = true;
        }
    }

    // 离开地面判断
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}