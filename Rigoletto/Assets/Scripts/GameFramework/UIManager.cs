using System.Collections;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GameFramework
{
    public class UIManager : MonoBehaviour
    {
        public GameObject loadGameButton;
        public GameObject loadingScreen;
        public Image loadingBarFill;

        public async void StartNewGame(int sceneID)
        {
            loadingScreen.SetActive(true);
            await Task.Delay(2000);
            LoadScene(sceneID);
            await Singleton.Instance.GameManager.LoadNaniNovel();
            //todo：写死的动画，只是展示功能
            loadingScreen.GetComponentInChildren<Image>().DOFade(0, 1.5f);
            loadingScreen.GetComponentInChildren<TMP_Text>().DOFade(0, 1.5f).OnComplete(()=>loadingScreen.SetActive(false));
            //初始化玩家角色
            //Singleton.Instance.CharacterManager.ConstructNewCharacter(Singleton.Instance.GameManager.mainCharacter,false,true);
        }
        
        public void LoadScene(int sceneID)
        {
            Singleton.Instance.LoadingManager.LoadScene(sceneID);
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
