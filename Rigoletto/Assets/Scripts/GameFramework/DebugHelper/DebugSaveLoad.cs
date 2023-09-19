using UnityEngine;
using UnityEngine.UI;

namespace GameFramework.DebugHelper
{
    public class DebugSaveLoad : MonoBehaviour
    {

        public Button SaveBtn, LoadBtn;
        // Start is called before the first frame update
        void Start()
        {
            SaveBtn.onClick.AddListener(delegate { Singleton.Instance.SaveLoadManager.SaveAllData(Singleton.Instance.SaveLoadManager.currentSlotID);});
            LoadBtn.onClick.AddListener(delegate { Singleton.Instance.SaveLoadManager.LoadAllData(1,false,Singleton.Instance.SaveLoadManager.currentSlotID); });
        }
    }
}
