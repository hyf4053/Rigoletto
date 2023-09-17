using Actors.Character;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjectClass
{
    /// <summary>
    /// 角色数据
    /// 注意，characterID务必和NaniNovel中对应的角色ID保持一致
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterData", order = 1)]
    public class CharacterData : ScriptableObject
    {
        public CharacterDataStructure data;
    }
}
