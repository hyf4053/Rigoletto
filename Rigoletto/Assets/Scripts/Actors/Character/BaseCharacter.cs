using System;
using GameFramework;
using ScriptableObjectClass;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Actors.Character
{
    /// <summary>
    /// 角色抽象类，不能直接使用
    /// </summary>
    public abstract class BaseCharacter : MonoBehaviour
    {
        //角色预定义数据，用于角色数据批量导入和初始化时使用的数据，该数据是原始数据任何变更不得发生在此处
        public CharacterData dataPredefined;

        //角色实际在游戏中会进行存取的数据内容，也是存档系统需要保存的内容
        public CharacterDataStructure dataToSave;

        private void Start()
        {

        }

        private void Update()
        {
        
        }
        

        /// <summary>
        /// 虚函数，可能会有部分初始化数据不一样
        /// </summary>
        public virtual void DataInit()
        {
            dataToSave.prefabID = dataPredefined.data.prefabID;
            dataToSave.characterID = dataPredefined.data.characterID;
            dataToSave.characterDisplayName = dataPredefined.data.characterDisplayName;
            dataToSave.isPlayer = dataPredefined.data.isPlayer;
        }

        public virtual void LoadData(CharacterDataStructure dataStructure)
        {
            dataToSave.prefabID = dataStructure.prefabID;
            dataToSave.characterID = dataStructure.characterID;
            dataToSave.characterDisplayName = dataStructure.characterDisplayName;
            dataToSave.isPlayer = dataStructure.isPlayer;
            
        }

    }
}
