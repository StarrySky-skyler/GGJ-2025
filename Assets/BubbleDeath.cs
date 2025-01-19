using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDeath : MonoBehaviour
{
    // 引用泡泡的Rigidbody 2D组件，方便后续操作
    private Rigidbody2D rb;

    // 信封Prefab引用
    public GameObject envelopePrefab;

    void Start()
    {
        // 在游戏开始时获取Rigidbody 2D组件
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测泡泡是否与地面或障碍物发生碰撞
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            // 如果碰撞到地面或障碍物，执行死亡操作
            Die();
        }
    }

    void Die()
    {
        // 可以在这里添加死亡效果，比如播放死亡动画、发出死亡音效等
        // 例如，播放一个简单的粒子效果来模拟泡泡破裂
        ParticleSystem ps = GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }

        // 播放死亡音效（需要提前在项目中导入音效文件，并创建一个AudioSource组件）
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        // 掉落信封
        Instantiate(envelopePrefab, transform.position, Quaternion.identity);

        // 销毁泡泡GameObject，使其从场景中消失
        Destroy(gameObject);
    }
}