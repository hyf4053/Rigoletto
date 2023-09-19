using GameFramework.Camera;
using GameFramework.SaveLoad;
using GameFramework.UI;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 单例管理类
    /// 只使用一个叫做Singleton的类，所有潜在的会作为单例出现的类用该类来管理
    /// </summary>
    public class Singleton : MonoBehaviour
    {
        public static Singleton Instance { get; private set; }
        //游戏管理类
        public GameManager GameManager { get; private set; }
        //角色管理类
        public CharacterManager CharacterManager { get; private set; }
        //存档管理类
        public SaveLoadManager SaveLoadManager { get; private set; }
        
        //加载管理器
        public LoadingManager LoadingManager { get; private set; }
        
        //UI管理类
        public UIManager UIManager { get; private set; }
        
        //相机管理类
        public CameraManager CameraManager { get; private set; }
        
        //调试类
        public DebugHelper.DebugHelper DebugHelper { get; private set; }
        
        private void Awake()
        {
            //管理可能出现的多实例的情况
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
            GameManager = GetComponentInChildren<GameManager>();
            CharacterManager = GetComponentInChildren<CharacterManager>();
            SaveLoadManager = GetComponentInChildren<SaveLoadManager>();
            UIManager = GetComponentInChildren<UIManager>();
            CameraManager = GetComponentInChildren<CameraManager>();
            LoadingManager = GetComponentInChildren<LoadingManager>();
            DebugHelper = GetComponentInChildren<DebugHelper.DebugHelper>();
        }

        private void Start()
        {
            //该管理类不会因为场景加载被销毁
            DontDestroyOnLoad(Instance);
        }
    }
}
