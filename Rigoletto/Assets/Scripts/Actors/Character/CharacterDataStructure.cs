using System;

namespace Actors.Character
{
    /// <summary>
    /// 角色数据结构
    /// </summary>
    [Serializable]
    public struct CharacterDataStructure
    {
        //预制件ID，用于在读取数据时，知道使用哪个预制件进行重新实例化
        public string prefabID;
        public string characterID;
        public string characterDisplayName;
        public bool isPlayer;
        public bool isNpc;
        public bool isMobs;
        public bool canDuplicated;
    }
}