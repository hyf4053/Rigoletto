using System;
using System.Threading.Tasks;
using UnityEngine;
using Naninovel;
using NaniNovelHelper.Commands;
using UnityEngine.UI;


namespace GameFramework
{
    /// <summary>
    /// 游戏管理类
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        //主要玩家角色，暂定
        public GameObject mainCharacter;
        //是否初始加载naninovel（后续应该是要弃用的）
        public bool loadNaniNovel;
        //游戏管理器数据
        public GameManagerData Data;

        //该事件只在主菜单的时候会触发，主要用于主菜单的一些初始化的时候的设置
        private void Awake()
        {
            /*if (Singleton.Instance != null)
            {
                Singleton.Instance.UIManager.loadGameButton.GetComponent<Button>().interactable = Singleton.Instance.SaveLoadManager.CheckSaveExist();
            }*/
        }


        // Start is called before the first frame update
        async void Start()
        {
            if (loadNaniNovel)
            {
               await LoadNaniNovel();
            }
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
            Singleton.Instance.CharacterManager.ConstructNewCharacter(mainCharacter,false,true);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
