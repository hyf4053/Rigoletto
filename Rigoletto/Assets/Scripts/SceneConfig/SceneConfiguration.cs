using System.Collections.Generic;
using UnityEngine;

namespace SceneConfig
{
    /// <summary>
    /// 场景配置表，保存内容之一
    /// 每个场景有一个属于自己的参数表，里面会记录相关的默认状态下刷新的对象信息
    /// 一旦GameManager是在初次加载时进入场景后，会立刻读取并保存数据
    /// 后续如果GameManager进入场时是因为LoadData进入时，该参数表会被忽略，同时会根据读取的参数表进行场景内容的生成
    /// </summary>
    public class SceneConfiguration : MonoBehaviour
    {
        //场景ID，用于匹配对应的参数表
        public string sceneID;
        //参数表，记录了需要刷新的参数
        public List<GameObject> prefabNeedToSpawn;
    }
}
