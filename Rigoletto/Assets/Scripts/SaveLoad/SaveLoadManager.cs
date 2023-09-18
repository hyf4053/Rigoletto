using System;
using System.Collections.Generic;
using Actors.Character;
using GameFramework;
using Naninovel;
using Naninovel.Commands;
using NaniNovelHelper.Commands;
using SceneConfig;
using UnityEngine;

namespace SaveLoad
{
    /// <summary>
    /// 保存加载类
    /// 主要使用Easy Save 3的功能去序列化或者保存游戏进度
    /// </summary>
    public class SaveLoadManager : MonoBehaviour
    {
        #region PRE-DEFINDED-DATA

        //最大存档栏位
        private readonly int MaxSaveSlot = 21;

        #endregion
        
        /// <summary>
        /// 存档栏位，用于存储存档的，这个栏位表示的是存档数据在Application.persistentDataPath下的子路径
        /// 因为玩家，NPC还有以后其他需要存档的内容，他们的ID不论存在哪个档位都是一样的
        /// 所以需要用路径区分具体的档位
        /// </summary>
        public List<string> saveSlot;
        
        //当前游戏的存档位
        public string currentSlotID;

        private void Awake()
        {
            //初始化存档位ID
            saveSlot = new List<string>();
            for (int i = 0; i < MaxSaveSlot; i++)
            {
                if (i == 0)
                {
                    saveSlot.Add("AutoSave");
                }
                saveSlot.Add("Save"+(i+1).ToString());
            }
        }


        /// <summary>
        /// 检查存档文件是否存在
        /// </summary>
        /// <returns>bool</returns>
        public bool CheckSaveExist()
        {
            return ES3.FileExists("Data.Save");
        }

        /// <summary>
        /// 根据给定的栏位检测是否有存档的存在
        /// </summary>
        /// <param name="slotID"></param>
        /// <returns></returns>
        public bool CheckSaveInGivenSlot(string slotID)
        {
            string path = Application.persistentDataPath + "/" + slotID + "/" + "Data.Save";
            return ES3.FileExists(path);
        }
        
        /// <summary>
        /// 加载GameManager的数据
        /// </summary>
        private void LoadGameManagerData()
        {
            if (ES3.KeyExists("GameManagerData"))
            {
                var s = (GameManagerData)ES3.Load("GameManagerData");
                Singleton.Instance.GameManager.Data.GameModeState = s.GameModeState;
            }
        }

        //存储角色数据
        public void SaveCharacterData(string slotID,string characterID, GameObject gameObjectToSave)
        {
            ES3.Save(characterID,gameObjectToSave,Application.persistentDataPath+"/"+slotID+"/"+"Data.Save");
        }

        //加载角色数据
        public void LoadCharacterData(string slotID, string characterID)
        {
            var i = (GameObject)ES3.Load(characterID, Application.persistentDataPath + "/" + slotID + "/" + "Data.Save");
            Singleton.Instance.CharacterManager.spawnedCharacters.Add(i);
            if (characterID == "Player")
            {
                Singleton.Instance.CameraManager.RebindCharacterToTheCamera(i,i,null);
            }
            
        }

        /// <summary>
        /// 根据角色ID检查存档是否存在，
        /// TODO：需要调整角色存档模式
        /// </summary>
        /// <param name="characterID"></param>
        /// <returns></returns>
        public bool CheckCharacterSave(string characterID)
        {
            return ES3.KeyExists(characterID);
        }
        
        /// <summary>
        /// 保存全部数据
        /// </summary>  
        public void SaveAllData(string slotID)
        {
            //存储GameManager Data的数据
            ES3.Save("GameManagerData",Singleton.Instance.GameManager.Data);
            
            //存储Character Data的数据
            foreach (var spawnedCharacter in Singleton.Instance.CharacterManager.spawnedCharacters)
            {
                SaveCharacterData(slotID,spawnedCharacter.GetComponentInChildren<BaseCharacter>().dataToSave.characterID,spawnedCharacter);
            }
            
            //游戏内容储存完之后，再保存一次NaniNovel的进度
            var naniNovelStateManager = Engine.GetService<IStateManager>();
            naniNovelStateManager.QuickSaveAsync();
        }

        /// <summary>
        /// 加载全部数据
        /// </summary>
        public async void LoadAllData(int sceneID, bool isNewGame, string slotID)
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
            
            //先加载GameManager数据
            LoadGameManagerData();
            //然后把对话状态缓存出来
            var mode = Singleton.Instance.GameManager.Data.GameModeState;
            //重新加载目标场景
            Singleton.Instance.LoadingManager.LoadScene(sceneID,false,slotID);
            //再次加载GameManager数据
            LoadGameManagerData();
            //加载NaniNovel数据（加载该数据时会自动开启对话UI）
            var naniNovelStateManager = Engine.GetService<IStateManager>();
            await naniNovelStateManager.QuickLoadAsync();
            if (Singleton.Instance.GameManager.Data.GameModeState == GameModeState.Adventure)
            {
                //隐藏对话UI
                var hidePrinter = new HidePrinter();
                await hidePrinter.ExecuteAsync();
            }
            //todo：跳转到某个具体模式



            // naniNovelStateManager.LoadGameAsync("Save1");
        }
    }
}
