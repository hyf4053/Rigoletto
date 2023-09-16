using System;

namespace Actors.Character
{
    /// <summary>
    /// 角色数据结构
    /// </summary>
    [Serializable]
    public struct CharacterDataStructure
    {
        public string characterID;
        public string characterDisplayName;
        public bool isPlayer;
        public bool isNpc;
        public bool isMobs;
        public bool canDuplicated;
    }
}