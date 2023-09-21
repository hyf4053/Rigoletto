using UnityEngine;

namespace StateActionsExtension
{
    /// <summary>
    /// 结构体，用于表达键盘这种只有0和1的控制器传达出的方向数据
    /// </summary>
    public struct InputDirection
    {
        public Vector2 FinalDirection;
        
        public InputDirection(KeyCode firstKey, KeyCode secondKey)
        {
            FinalDirection = Vector2.zero;
        }
       
       
    }
}
