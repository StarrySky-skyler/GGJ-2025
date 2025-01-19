using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    public float speed = 5.0f; //玩家移动速度
    public int score = 0;//玩家得分
    public int bubbleCapacity = 10;//泡泡承载量

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score:" +  score);
    }

    public void Usebubble()
    {
        if (bubbleCapacity > 0)
        {
            bubbleCapacity--;
            Debug.Log("No bubbles left.");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player died!");
            // 重置玩家位置或游戏结束逻辑
        }
    }
}
