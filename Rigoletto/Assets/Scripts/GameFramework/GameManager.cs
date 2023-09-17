using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actors.Character;
using UnityEngine;
using Naninovel;
using NaniNovelHelper.Commands;
using SceneConfig;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace GameFramework
{
    /// <summary>
    /// 游戏管理类
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        //是否初始加载naninovel（后续应该是要弃用的）
        public bool loadNaniNovel;
        //游戏管理器数据
        public GameManagerData Data;
        
        //场景中已经刷新的目标，用于覆盖SceneConfiguration的数据
        //public List<GameObject> AllSpawnedGameObjects;
        
        //场景中角色类型的存档数据
        //public List<CharacterDataStructure> LoadedSpawnedCharacterData;
        
        //用于获取当前场景的默认配置表信息，然后会和存档中对比是否有同ID的配置表，如果有，则更新数据到场景配置表中并根据最新的配置表生成场景内容
        public SceneConfiguration SceneConfiguration;

        //该事件只在主菜单的时候会触发，主要用于主菜单的一些初始化的时候的设置
        private void Awake()
        {
            GetCurrentSceneID();
            if (Singleton.Instance != null && Data.CurrentSceneID == 0)
            {
                Singleton.Instance.UIManager.loadGameButton.GetComponent<Button>().interactable = Singleton.Instance.SaveLoadManager.CheckSaveExist();
            }
        }


        // Start is called before the first frame update
        async void Start()
        {
            if (loadNaniNovel)
            {
               await LoadNaniNovel();
            }
        }

        public void LoadGameManagerData()
        {
            if (ES3.KeyExists("GameManagerData"))
            {
                var s = (GameManagerData)ES3.Load("GameManagerData");
                Data.GameModeState = s.GameModeState;
            }
        }

        /// <summary>
        /// 获取当前已加载的场景ID
        /// </summary>
        public void GetCurrentSceneID()
        {
            Data.CurrentSceneID = SceneManager.GetActiveScene().buildIndex;
        }

        public async Task LoadNaniNovel(GameModeState mode = GameModeState.Adventure)
        {
            //1.手动异步加载NaniNovel
            Debug.Log("Start Init NaniNovel...");
            await RuntimeInitializer.InitializeAsync();
            Debug.Log("NaniNovel Loaded!");

            if (mode == GameModeState.Adventure)
            {
                //2.初始化冒险模式（以后也可能是其他的模式）
                var switchCommand = new SwitchToAdventureMode
                {
                    ResetState = false
                };
            
                Debug.Log("AdvMode Switching...");
                await switchCommand.ExecuteAsync();
                Debug.Log("Switch To AdvMode");
            }

            if (mode == GameModeState.Dialogue)
            {
                
            }
            
        }

        /// <summary>
        /// 更新游戏模式状态
        /// </summary>
        /// <param name="newState">更新后的状态</param>
        public void ChangeGameModeState(GameModeState newState)
        {
            Data.GameModeState = newState;
        }
        
        /// <summary>
        /// 退出游戏的函数
        /// </summary>
        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        
        /// <summary>
        /// 移除并清空全部的角色对象，通常在重新加载某个场景时需要调用
        /// </summary>
        /*public void ClearSpawnedCharacterList()
        {
            foreach (var spawnedInstance in AllSpawnedGameObjects)
            {
                Destroy(spawnedInstance);
            }
            AllSpawnedGameObjects.Clear();
        }*/

        /*public void AddGameObjectToTheList(GameObject spawned)
        {
            AllSpawnedGameObjects.Add(spawned);
            //LoadedSpawnedCharacterData.Add((MainCharacter)spawned);
        }*/

        // Update is called once per frame
        void Update()
        {
        
        }
        
        
    }
}
