using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    public float speed = 5.0f; //����ƶ��ٶ�
    public int score = 0;//��ҵ÷�
    public int bubbleCapacity = 10;//���ݳ�����

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
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
            // �������λ�û���Ϸ�����߼�
        }
    }
}
