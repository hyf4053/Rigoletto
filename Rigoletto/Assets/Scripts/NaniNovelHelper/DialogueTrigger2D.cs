using System;
using Naninovel;
using UnityEngine;

namespace NaniNovelHelper
{
    public class DialogueTrigger2D : MonoBehaviour
    {
        public string ScriptName;

        public string Label;

        private void OnTriggerEnter2D(Collider2D other)
        {
            //启用Nani的输入输出控制
            var inputManager = Engine.GetService<IInputManager>();
            inputManager.ProcessInput = true;

            var scriptPlayer = Engine.GetService <IScriptPlayer>();
            scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label).Forget();
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
