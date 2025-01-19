// ********************************************************************************
// @author: Starry Sky
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/01/19 11:01
// @version: 1.0
// @description:
// ********************************************************************************

using UnityEngine;

namespace Tsuki.Objs
{
    public class SongShu : CollideDeadObj
    {
        public void DestorySelf()
        {
            Destroy(gameObject);
        }
    }
}
