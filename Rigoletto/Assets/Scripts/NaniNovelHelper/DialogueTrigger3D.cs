using NaniNovelHelper.Commands;
using UnityEngine;

namespace NaniNovelHelper
{
    /// <summary>
    /// 基础对话触发器3D版，进入Trigger就会开始执行给定的Nani脚本
    /// </summary>
    public class DialogueTrigger3D : MonoBehaviour
    {
        public string ScriptName;

        public string Label;

        private async void OnTriggerEnter(Collider other)
        {
            var switchToDialogueMode = new SwitchToDialogueMode
            {
                ScriptName = this.ScriptName, Label = this.Label
            };

            await switchToDialogueMode.ExecuteAsync();
        }
    }
}
