using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        //用于获取当前场景的默认配置表信息，然后会和存档中对比是否有同ID的配置表，如果有，则以存档中的配置表为基础生成
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

        /// <summary>
        /// 获取当前已加载的场景ID
        /// </summary>
        public void GetCurrentSceneID()
        {
            Data.CurrentSceneID = SceneManager.GetActiveScene().buildIndex;
        }

        public async Task LoadNaniNovel()
        {
            //1.手动异步加载NaniNovel
            Debug.Log("Start Init NaniNovel...");
            await RuntimeInitializer.InitializeAsync();
            Debug.Log("NaniNovel Loaded!");
            
            //2.初始化冒险模式（以后也可能是其他的模式）
            var switchCommand = new SwitchToAdventureMode
            {
                ResetState = false
            };
            
            Debug.Log("AdvMode Switching...");
            await switchCommand.ExecuteAsync();
            Debug.Log("Switch To AdvMode");

            //初始化玩家角色
            //Singleton.Instance.CharacterManager.ConstructNewCharacter(mainCharacter,false,true);
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

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
