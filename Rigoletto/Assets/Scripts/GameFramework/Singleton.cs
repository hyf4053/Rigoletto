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
        public GameManager GameManager { get; private set; }
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
            GameManager = GetComponentInChildren<GameManager>();
        }

        private void Start()
        {
            DontDestroyOnLoad(Instance);
        }
    }
}
