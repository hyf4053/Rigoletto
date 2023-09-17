using System.Collections.Generic;
using Actors.Character;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 角色管理器
    /// 用于管理角色的实例化以及相关的数据处理
    /// </summary>
    public class CharacterManager : MonoBehaviour
    {
        //已刷新的角色列表, 用于管理刷新出来的角色实例
        public List<GameObject> spawnedCharacters;

        /// <summary>
        /// 构建一个新角色
        /// </summary>
        /// <param name="characterPrefab">角色的Prefab</param>
        /// <param name="bCanDuplicated">是否可以重复，默认false</param>
        /// <param name="bNeedRebindCamera">是否需要重绑定至主相机，默认false</param>
        /// <returns></returns>
        public bool ConstructNewCharacter(GameObject characterPrefab,bool bCanDuplicated = false, bool bNeedRebindCamera = false)
        {
            if (bCanDuplicated)
            {
                var temp1 = Instantiate(characterPrefab);
                temp1.GetComponentInChildren<BaseCharacter>().DataInit();
                spawnedCharacters.Add(temp1); 
                if(bNeedRebindCamera) Singleton.Instance.CameraManager.RebindCharacterToTheCamera(temp1,temp1,Singleton.Instance.CameraManager.mainVirtualCamera);
                return true;
            }
            var temp2 = Instantiate(characterPrefab);
            if (temp2 == null || spawnedCharacters.Contains(temp2)) return false;
            temp2.GetComponentInChildren<BaseCharacter>().DataInit();
            spawnedCharacters.Add(temp2);
            if(bNeedRebindCamera) Singleton.Instance.CameraManager.RebindCharacterToTheCamera(temp2,temp2,Singleton.Instance.CameraManager.mainVirtualCamera);
            return true;
        }
        
        //public bool ConstructCharacterFromSaveData()
    }
}
