using System.Collections;
using SceneConfig;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFramework
{
    public class LoadingManager : MonoBehaviour
    {
        /// <summary>
        /// 加载某个场景，该场景会按照初始编写好的状态加载
        /// </summary>
        /// <param name="sceneID"></param>
        public void LoadScene(int sceneID, bool isNewGame, string slotID)
        {
            StartCoroutine(LoadSceneAsync(sceneID,isNewGame,slotID));
        }
        
        /// <summary>
        /// 异步加载场景
        /// </summary>
        /// <param name="sceneID"></param>
        /// <returns></returns>
        IEnumerator LoadSceneAsync(int sceneID, bool isNewGame, string slotID)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

            while (!operation.isDone)
            {
                yield return null;
            }
            //加载完成后, 搜寻新场景中的配置信息表
            Singleton.Instance.GameManager.sceneConfiguration = FindObjectOfType<SceneConfiguration>();
            //卸载并清空之前已经加载的实例
            Singleton.Instance.CharacterManager.ClearSpawnedCharacterList();
            //更新场景ID
            Singleton.Instance.GameManager.GetCurrentSceneID();
            //更新主相机信息
            Singleton.Instance.CameraManager.DisplaceMainCamera();
            
            if (isNewGame)
            {
                Singleton.Instance.CharacterManager.ConstructNewCharacter(Singleton.Instance.GameManager.sceneConfiguration.prefabNeedToSpawn[0],false,true);
                
            }
            else
            {
                Singleton.Instance.SaveLoadManager.LoadCharacterData(slotID,"Player");
            } 
        }
        
    }
}
