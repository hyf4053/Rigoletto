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
            //更新场景ID
            Singleton.Instance.GameManager.GetCurrentSceneID();
            //更新主相机信息
            Singleton.Instance.CameraManager.RedisplaceMainCamera();
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
