using Character;
using UnityEngine;
using Naninovel;
using NaniNovelHelper.Commands;

namespace GameFramework
{
    /// <summary>
    /// 游戏管理类
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public GameObject mainCharacter;
        
        // Start is called before the first frame update
        async void Start()
        {
            //1.手动异步加载NaniNovel
            Debug.Log("Start Init NaniNovel...");
            await RuntimeInitializer.InitializeAsync();
            Debug.Log("NaniNovel Loaded!");
            
            //2.初始化冒险模式
            var switchCommand = new SwitchToAdventureMode
            {
                ResetState = false
            };
            
            Debug.Log("AdvMode Switching...");
            await switchCommand.ExecuteAsync();
            Debug.Log("Switch To AdvMode");

            Instantiate(mainCharacter);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
