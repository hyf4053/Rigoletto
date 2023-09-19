using System.Threading.Tasks;
using UnityEngine;
using Naninovel;
using NaniNovelHelper.Commands;
using SceneConfig;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;


namespace GameFramework
{
    /// <summary>
    /// 游戏管理类
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        
        //游戏管理器数据
        [FormerlySerializedAs("Data")] public GameManagerData data;
        
        //用于获取当前场景的默认配置表信息，然后会和存档中对比是否有同ID的配置表，如果有，则更新数据到场景配置表中并根据最新的配置表生成场景内容
        [FormerlySerializedAs("SceneConfiguration")] public SceneConfiguration sceneConfiguration;

        //该事件只在主菜单的时候会触发，主要用于主菜单的一些初始化的时候的设置
        private void Awake()
        {
            GetCurrentSceneID();
            if (Singleton.Instance != null && data.CurrentSceneID == 0)
            {
                Singleton.Instance.UIManager.loadGameButton.GetComponent<Button>().interactable = Singleton.Instance.SaveLoadManager.CheckSaveExist();
            }
        }
        
        /// <summary>
        /// 获取当前已加载的场景ID
        /// </summary>
        public void GetCurrentSceneID()
        {
            data.CurrentSceneID = SceneManager.GetActiveScene().buildIndex;
        }

        public async Task LoadNaniNovel(GameModeState mode = GameModeState.Adventure)
        {
            //1.手动异步加载NaniNovel
            await RuntimeInitializer.InitializeAsync();

            if (mode == GameModeState.Adventure)
            {
                //2.初始化冒险模式（以后也可能是其他的模式）
                var switchCommand = new SwitchToAdventureMode
                {
                    ResetState = false
                };
                await switchCommand.ExecuteAsync();
            }
        }

        /// <summary>
        /// 更新游戏模式状态
        /// </summary>
        /// <param name="newState">更新后的状态</param>
        public void ChangeGameModeState(GameModeState newState)
        {
            data.GameModeState = newState;
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
    }
}
