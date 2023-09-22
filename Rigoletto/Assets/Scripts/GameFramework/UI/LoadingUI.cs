using UnityEngine;

namespace GameFramework.UI
{
    /// <summary>
    /// 目前这个就是为了保证有些UI跨场景不会被删除
    /// </summary>
    public class LoadingUI : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(this);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
