using ScriptableObjectClass;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character
{
    /// <summary>
    /// 角色抽象类，不能直接使用
    /// </summary>
    public abstract class BaseCharacter : MonoBehaviour
    {
        public CharacterData data;
    }
}
