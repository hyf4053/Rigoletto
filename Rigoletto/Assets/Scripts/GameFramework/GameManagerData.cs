using System;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 游戏当前模式，目前就只有两种模式，一种是探索模式，一种是对话模式
    /// 该模式会在每次和NaniNovel插件进行交互时事实更新状态
    /// </summary>
    [Serializable]
    public enum GameModeState
    {
        Adventure,
        Dialogue
    }
    /// <summary>
    /// 游戏管理器的一些数据，可以看作一些全局变量
    /// 一些是用来记录功能类的变量
    /// </summary>
    [Serializable]
    public struct GameManagerData
    {
        //判断是否是开始的新游戏，用于决定在新游戏整个场景加载好之后进行存档
        public bool IsStartFromNewGame;
        
        //存档ID，目前没有起到作用，该ID的作用是给存档分Slot，同时会作为保存路径
        public string SaveID;

        //当前游戏模式状态
        public GameModeState GameModeState;

        //当前场景ID
        public int CurrentSceneID;

    }
}
