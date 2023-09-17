using System;
using Actors.Character;
using GameFramework;
using Naninovel;
using Naninovel.Commands;
using NaniNovelHelper.Commands;
using UnityEngine;

namespace SaveLoad
{
    /// <summary>
    /// 保存加载类
    /// 主要使用Easy Save 3的功能去序列化或者保存游戏进度
    /// todo:需要想办法让这个进度和NaniNovel的进度同步，或者说，这个保存类进行存档的时候，NaniNovel也需要调用存档。
    /// </summary>
    public class SaveLoadManager : MonoBehaviour
    {
        
        private void Start()
        {
        }

        private void OnApplicationQuit()
        {
            //SaveAllData();
        }

        public bool CheckSaveExist()
        {
            return ES3.FileExists("Data.Save");
        }

        /// <summary>
        /// 保存全部数据
        /// </summary>
        public void SaveAllData()
        {
            //存储GameManager的状态
            ES3.Save("GameManager",Singleton.Instance.GameManager.Data);
            //遍历刷新出来的角色，根据每个NPC的ID，对dataToSave的内容进行存储
            foreach (var character in Singleton.Instance.CharacterManager.spawnedCharacters)
            {
                ES3.Save(character.GetComponentInChildren<BaseCharacter>().dataToSave.characterID,character.GetComponentInChildren<BaseCharacter>().dataToSave);
            }
            //游戏内容储存完之后，再保存一次NaniNovel的进度
            var naniNovelStateManager = Engine.GetService<IStateManager>();
            naniNovelStateManager.QuickSaveAsync();

            // naniNovelStateManager.LoadGameAsync("Save1");
            // naniNovelStateManager.sav
            //Debug.Log("Save Done");
        }

        /// <summary>
        /// 加载全部数据
        /// </summary>
        public async void LoadAllData()
        {
            /*
             * 加载方式：
             * 1.重新加载存档的目标场景
             * 2.根据存档数据，初始化对应实例
             * 3.将存档数据加载进实例中
             * 4.完成加载
             * 例如：
             * 1.载入场景A
             * 2.等待A场景初始化完成
             * 3.根据存档内容加载对应的对象
             * 4.完成加载
             */
            
            //重新加载目标场景
            Singleton.Instance.UIManager.StartNewGame(Singleton.Instance.GameManager.Data.CurrentSceneID);
            //Singleton.Instance.CharacterManager.ConstructNewCharacter(Singleton.Instance.GameManager.mainCharacter,false,true);
            
            //todo：加载存档数据
            //加载GameManager数据
            
            /*
            //加载NaniNovel数据（加载该数据时会自动开启对话UI）
            var naniNovelStateManager = Engine.GetService<IStateManager>();
            await naniNovelStateManager.QuickLoadAsync();
            
            //隐藏对话UI
            var hidePrinter = new HidePrinter();
            await hidePrinter.ExecuteAsync();
            */
            
            //todo：跳转到某个具体模式



            // naniNovelStateManager.LoadGameAsync("Save1");
        }
    }
}
