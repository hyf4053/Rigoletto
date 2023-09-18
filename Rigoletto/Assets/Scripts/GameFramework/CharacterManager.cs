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
        /// 构建一个新角色,构建完成后角色数据结构会在此处进行保存
        /// </summary>
        /// <param name="characterPrefab">角色的Prefab</param>
        /// <param name="bCanDuplicated">是否可以重复，默认false</param>
        /// <param name="bNeedRebindCamera">是否需要重绑定至主相机，默认false</param>
        /// <returns></returns>
        public void ConstructNewCharacter(GameObject characterPrefab,bool bCanDuplicated = false, bool bNeedRebindCamera = false)
        {
            if (bCanDuplicated)
            {
                var temp1 = Instantiate(characterPrefab);
                temp1.GetComponentInChildren<BaseCharacter>().DataInit();
                spawnedCharacters.Add(temp1); 
                Singleton.Instance.SaveLoadManager.SaveCharacterData("A",temp1.GetComponentInChildren<BaseCharacter>().dataToSave.characterID,temp1);
                if(bNeedRebindCamera) Singleton.Instance.CameraManager.RebindCharacterToTheCamera(temp1,temp1,Singleton.Instance.CameraManager.mainVirtualCamera);
                return;
            }
            var temp2 = Instantiate(characterPrefab);
            if (temp2 == null || spawnedCharacters.Contains(temp2)) return;
            temp2.GetComponentInChildren<BaseCharacter>().DataInit();
            spawnedCharacters.Add(temp2);
            Singleton.Instance.SaveLoadManager.SaveCharacterData("A",temp2.GetComponentInChildren<BaseCharacter>().dataToSave.characterID,temp2);
            if(bNeedRebindCamera) Singleton.Instance.CameraManager.RebindCharacterToTheCamera(temp2,temp2,Singleton.Instance.CameraManager.mainVirtualCamera);
            return;
        }

        public void ConstructCharacterFromSave()
        {
            foreach (var prefab in Singleton.Instance.GameManager.SceneConfiguration.prefabNeedToSpawn)
            {
                if (Singleton.Instance.SaveLoadManager.CheckCharacterSave(prefab.GetComponentInChildren<BaseCharacter>()
                        .dataPredefined.data.characterID))
                {
                    var temp2 = Instantiate(prefab);
                    var s = (CharacterDataStructure)ES3.Load(prefab.GetComponentInChildren<BaseCharacter>().dataPredefined.data.characterID);
                    temp2.GetComponentInChildren<BaseCharacter>().LoadData(s);
                    /*Singleton.Instance.SaveLoadManager.LoadCharacterTransform(prefab
                            .GetComponentInChildren<BaseCharacter>().dataPredefined.data.characterID,temp2.transform);*/
                    spawnedCharacters.Add(temp2);
                    Singleton.Instance.CameraManager.RebindCharacterToTheCamera(temp2,temp2,Singleton.Instance.CameraManager.mainVirtualCamera);
                }
            }
        }

        /// <summary>
        /// 移除并清空全部的角色对象，通常在重新加载某个场景时需要调用
        /// </summary>
        public void ClearSpawnedCharacterList()
        {
            foreach (var character in spawnedCharacters)
            {
                Destroy(character);
            }
            spawnedCharacters.Clear();
        }
        
        //public bool ConstructCharacterFromSaveData()
    }
}
