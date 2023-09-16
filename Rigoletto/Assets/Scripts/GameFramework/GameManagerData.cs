using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 游戏管理器的一些数据，可以看作一些全局变量
    /// 一些是用来记录功能类的变量
    /// </summary>
    public struct GameManagerData
    {
        //判断是否是开始的新游戏，用于决定在新游戏整个场景加载好之后进行存档
        public bool IsStartFromNewGame;
        
        //存档ID
        public string SaveID;


    }
}
