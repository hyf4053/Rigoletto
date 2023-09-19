using TMPro;
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

        public TMP_Text w;
        public TMP_Text a;
        public TMP_Text s;
        public TMP_Text d;
        public void WPress()
        {
            w.color = Color.green;
        }
        public void APress()
        {
            a.color = Color.green;
        }
        
        public void SPress()
        {
            s.color = Color.green;
        }
        
        public void DPress()
        {
            d.color = Color.green;
        }
        
        public void WR()
        {
            w.color = Color.red;
        }
        public void AR()
        {
            a.color = Color.red;
        }
        
        public void SR()
        {
            s.color = Color.red;
        }
        
        public void DR()
        {
            d.color = Color.red;
        }
    }
}
