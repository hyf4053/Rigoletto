using System.Collections;
using SceneConfig;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFramework
{
    public class LoadingManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        /// <summary>
        /// 加载某个场景，该场景会按照初始编写好的状态加载
        /// </summary>
        /// <param name="sceneID"></param>
        public void LoadScene(int sceneID)
        {
            StartCoroutine(LoadSceneAsync(sceneID));
        }
        
        /// <summary>
        /// 异步加载场景
        /// </summary>
        /// <param name="sceneID"></param>
        /// <returns></returns>
        IEnumerator LoadSceneAsync(int sceneID)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

            while (!operation.isDone)
            {
                yield return null;
            }
            //加载完成后, 搜寻新场景中的配置信息表
            Singleton.Instance.GameManager.SceneConfiguration = FindObjectOfType<SceneConfiguration>();
            
            //卸载并清空之前已经加载的实例
            Singleton.Instance.CharacterManager.ClearSpawnedCharacterList();
          //  Singleton.Instance.GameManager.ClearSpawnedCharacterList();
            
            //更新场景ID
            Singleton.Instance.GameManager.GetCurrentSceneID();
            
            //更新主相机信息
            Singleton.Instance.CameraManager.RedisplaceMainCamera();
            
            //尝试读取是否有对应场景的存档，如果有则覆盖当前默认的场景配置内容
            //Singleton.Instance.SaveLoadManager.TryToLoadSceneConfigData(Singleton.Instance.GameManager.SceneConfiguration.sceneID, Singleton.Instance.GameManager.SceneConfiguration);
            /*Singleton.Instance.SaveLoadManager.TryToLoadSceneConfigData(Singleton.Instance.GameManager.SceneConfiguration.sceneID,
                Singleton.Instance.GameManager.LoadedSpawnedGameObjectsData);*/
            
            //根据场景配置表加载相关内容
            /*if (Singleton.Instance.GameManager.LoadedSpawnedGameObjectsData.Count > 0)
            {
                Singleton.Instance.CharacterManager.ConstructNewCharacter(Singleton.Instance.GameManager.SceneConfiguration.prefabNeedToSpawn[0],false,true);
            }
            else
            {*/
            //TODO:Save Slot
            if (ES3.FileExists("Data.Save"))
            {
                Singleton.Instance.CharacterManager.ConstructCharacterFromSave();
            }
            else
            {
                Singleton.Instance.CharacterManager.ConstructNewCharacter(Singleton.Instance.GameManager.SceneConfiguration.prefabNeedToSpawn[0],false,true);
            } 
            
        }
        
    }
}
