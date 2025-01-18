// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 11:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using UnityEngine;

namespace Tsuki.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        /// <summary>
        /// 分数
        /// </summary>
        public int score;

        private void Awake()
        {
            Instance = this;
            // 限制最高帧率
            Application.targetFrameRate = 160;
        }
    }
}
