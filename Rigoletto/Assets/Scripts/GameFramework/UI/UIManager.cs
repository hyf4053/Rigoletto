using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameFramework.UI
{
    public class UIManager : MonoBehaviour
    {
        public GameObject loadGameButton;
        public GameObject loadingScreen;
        public Image loadingBarFill;
        public GameObject mainUI;
        
        

        public GameObject loadSlotSelectionUI;
        public GameObject saveSlotUI;

        [Tooltip("该list记录了所有被打开的UI（除了主UI自己），用于后续一些界面的关闭顺序记录")]
        public List<GameObject> uiLayerList;

        private void Start()
        {
            SpawnSaveSlots();
        }

        /// <summary>
        /// 开始新游戏，绑定于新游戏按钮
        /// </summary>
        public void StartNewGame()
        {
            OpenSelectLoadSlotUI();
            
            /*loadingScreen.SetActive(true);
            await Task.Delay(2000);
            LoadScene(sceneID);
            await Singleton.Instance.GameManager.LoadNaniNovel();
            //todo：写死的动画，只是展示功能
            loadingScreen.GetComponentInChildren<Image>().DOFade(0, 1.5f);
            loadingScreen.GetComponentInChildren<TMP_Text>().DOFade(0, 1.5f).OnComplete(()=>loadingScreen.SetActive(false));*/
        }

        /// <summary>
        /// 打开选择存档位置的UI
        /// </summary>
        public void OpenSelectLoadSlotUI()
        {
            OpenNewUi(loadSlotSelectionUI);
        }

        private void SpawnSaveSlots()
        {
            var i = saveSlotUI.GetComponent<ScrollUIOptionSpawn>();

            foreach (var slotID in Singleton.Instance.SaveLoadManager.saveSlot)
            {
                GameObject btn;
                if (Singleton.Instance.SaveLoadManager.CheckSaveInGivenSlot(slotID))
                {
                    
                    i.SpawnButtonObject(slotID,Color.red,out btn);
                    btn.GetComponent<Button>().onClick
                        .AddListener(delegate { LoadGameWithMode(1,slotID,mainUI,GameModeState.Adventure); });
                }
                else
                {
                    i.SpawnButtonObject(slotID,Color.green,out btn);
                    btn.GetComponent<Button>().onClick.
                        AddListener(delegate { CreateNewSaveAndStartNewGame(slotID,mainUI);});
                }
            }
        }

        /// <summary>
        /// 针对可以创建存档的档位绑定的函数
        /// 点击后可以创建新存档栏位，然后开始加载新游戏
        /// </summary>
        private void CreateNewSaveAndStartNewGame(string slotID,GameObject ui)
        {
            StartNewGameWithMode(1,true,slotID);
            ui.SetActive(false);
        }

        /// <summary>
        /// todo：针对已有存档的档位绑定的函数
        /// todo：点击后跳出确认界面，是否要覆盖存档，如果是则覆盖存档并开启新游戏
        /// </summary>
        public void OverrideExistSaveDataAndStartNewGame(int sceneID, string slotID,GameModeState mode)
        {
           LoadGameWithMode(sceneID,slotID,mainUI,mode);
           //ui.SetActive(false);
        }

        /// <summary>
        /// 打开一个新UI界面
        /// </summary>
        /// <param name="uiOpen"></param>
        public void OpenNewUi(GameObject uiOpen)
        {
            uiOpen.SetActive(true);
            uiLayerList.Add(uiOpen);
        }
        
        /// <summary>
        /// 关闭最后一个UI
        /// </summary>
        public void CloseTopUI()
        {
            uiLayerList[^1].GetComponent<CanvasGroup>().DOFade(0, 0.5f)
                .OnComplete(() =>
                {
                    uiLayerList[^1].SetActive(false);
                    uiLayerList.RemoveAt(uiLayerList.Count-1);
                });
        }
        
        /// <summary>
        /// 只用于游戏的第一次初始化，并不用于其他地方
        /// </summary>
        /// <param name="sceneID">初始化的场景Index</param>
        /// <param name="mode">初始化时游戏模式</param>
        private async void StartNewGameWithMode(int sceneID, bool isNewGame, string slotID,GameModeState mode = GameModeState.Adventure)
        {
            //目前考虑这个用作debug的栏位暂存
            Singleton.Instance.SaveLoadManager.currentSlotID = slotID;
            loadingScreen.SetActive(true);
            await Task.Delay(2000);
            LoadScene(sceneID,isNewGame,slotID);
            await Singleton.Instance.GameManager.LoadNaniNovel(mode);
            //todo：写死的动画，只是展示功能
            loadingScreen.GetComponentInChildren<Image>().DOFade(0, 1.5f);
            loadingScreen.GetComponentInChildren<TMP_Text>()
                .DOFade(0, 1.5f)
                .OnComplete(()=>loadingScreen.SetActive(false));
            
            Singleton.Instance.SaveLoadManager.SaveAllData(slotID);
        }

        private async void LoadGameWithMode(int sceneID, string slotID,GameObject ui,
            GameModeState mode = GameModeState.Adventure)
        {
            //目前考虑这个用作debug的栏位暂存
            Singleton.Instance.SaveLoadManager.currentSlotID = slotID;
            
            loadingScreen.SetActive(true);
            await Task.Delay(2000);
            LoadScene(sceneID,false,slotID);
            ui.SetActive(false);
            //todo:这里可能会导致重复加载NaniNovel插件，要注意
            await Singleton.Instance.GameManager.LoadNaniNovel(mode);
            //todo：写死的动画，只是展示功能
            loadingScreen.GetComponentInChildren<Image>().DOFade(0, 1.5f);
            loadingScreen.GetComponentInChildren<TMP_Text>().DOFade(0, 1.5f).OnComplete(()=>loadingScreen.SetActive(false));
        }
        
        private void LoadScene(int sceneID, bool isNewGame, string slotID)
        {
            Singleton.Instance.LoadingManager.LoadScene(sceneID,isNewGame,slotID);
        }
        
        
        /// <summary>
        /// 退出游戏的函数
        /// </summary>
        public void ExitGame()
        {
            Singleton.Instance.GameManager.ExitGame();
        }
    }
}
