// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 23:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Tsuki.Objs
{
    public class AutoDestoryObj : MonoBehaviour
    {
        public float lifeTime;

        protected virtual void Start()
        {
            Destroy(gameObject, lifeTime);
        }
    }
}
