// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/18 11:01
// @version: 1.0
// @description:
// ********************************************************************************

using System;
using Tsuki.Weather;
using UnityEngine;

namespace Tsuki.Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}
