using UnityEngine;

namespace PrefabConfig
{
    /// <summary>
    /// 预制件类型，用于决定该预制件由什么类实例化
    /// </summary>
    public enum PrefabType
    {
        Player,
        Character
    }
    public class PrefabConfig : MonoBehaviour
    {
        //预制件类型，用于和存档关联，了解使用什么数据对该预制件初始化
        public PrefabType PrefabType;

        //预制件ID，用于和存档关联，了解使用什么数据对该预制件初始化
        public string PrefabID;
    }
}
