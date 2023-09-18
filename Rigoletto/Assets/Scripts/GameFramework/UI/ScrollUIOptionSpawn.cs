using TMPro;
using UnityEngine;

namespace GameFramework.UI
{
    /// <summary>
    /// 负责刷新相关的UI内容
    /// </summary>
    public class ScrollUIOptionSpawn : MonoBehaviour
    {
        public GameObject buttonUI;

        public GameObject spawnNode;

        public void SpawnButtonObject(string text, Color color, out GameObject button)
        {
            var o = Instantiate(buttonUI, spawnNode.transform);
            button = o;
            var tmp = o.GetComponentInChildren<TMP_Text>();
            tmp.SetText(text);
            tmp.color = color;
        }
    }
}
