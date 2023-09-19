using UnityEngine;
using UnityEngine.UI;

namespace GameFramework.DebugHelper
{
    
    public delegate void DelegateFuncLoad(int sceneID, bool isNewGame, string slotID);
    public class DebugHelper : MonoBehaviour
    {
        public void BindFunctionToBtn(Button targetButton,int sceneID, bool isNewGame, string slotID, DelegateFuncLoad delegateFunc)
        {
            targetButton.onClick.AddListener(delegate { delegateFunc(sceneID, isNewGame, slotID);});
        }
    }
}
