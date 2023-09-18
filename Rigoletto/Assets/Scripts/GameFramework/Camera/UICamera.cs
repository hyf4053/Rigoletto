using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameFramework.Camera
{
    /// <summary>
    /// UI相机
    /// </summary>
    public class UICamera : MonoBehaviour
    {
        [Tooltip("需要显示的UI Canvas")]
        public GameObject uiCanvas;

        private void Awake()
        {
            if (uiCanvas == null)
            {
                Debug.LogError("No Canvas on camera!");
            }
            
            var canvas = uiCanvas.GetComponent<Canvas>();
            canvas.worldCamera = this.GetComponent<UnityEngine.Camera>();
        }
    }
}
