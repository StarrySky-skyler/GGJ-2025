﻿// ********************************************************************************
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
    public class PickObj : MonoBehaviour
    {
        public float speed;
        
        private Rigidbody2D _rb2D;

        private void Awake()
        {
            _rb2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rb2D.velocity = new Vector2(-1f, -1f) * speed;
            Destroy(gameObject, 10f);
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
