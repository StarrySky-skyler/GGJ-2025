// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 17:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using Tsuki.Managers;
using UnityEngine;

namespace Tsuki.Objs
{
    // TODO: 鱼，兔子，松鼠，灌木丛
    public class PickObj : AutoDestoryObj
    {
        public float speed;
        
        private Rigidbody2D _rb2D;

        private void Awake()
        {
            _rb2D = GetComponent<Rigidbody2D>();
        }

        protected override void Start()
        {
            _rb2D.velocity = new Vector2(-1f, -1f) * speed;
            base.Start();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            switch (gameObject.tag)
            {
                case "Flower":
                    GameManager.Instance.Score += 5;
                    break;
                case "Leaf":
                    GameManager.Instance.Score += 3;
                    break;
                case "Snow":
                    GameManager.Instance.Score += 2;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
