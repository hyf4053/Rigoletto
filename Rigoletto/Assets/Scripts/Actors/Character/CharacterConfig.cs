using UnityEngine;

namespace Actors.Character
{
    /// <summary>
    /// 角色配置
    /// </summary>
    
    [CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/CharacterConfig", order = 1)]
    public class CharacterConfig : ScriptableObject
    {
        public int extraJumps = 0;
        public int airDashes = 0;
        public float invulnerableTime = 0;
        
    }
}
