using NaniNovelHelper.Commands;
using UnityEngine;
namespace NaniNovelHelper
{
    /// <summary>
    /// 基础对话触发器，2D版，进入Trigger就会开始执行给定的Nani脚本
    /// 注意2D的OnTriggerEnter2D存在一个问题，他无视了z轴
    /// 也就是说如果是纯平2D，没有z轴的版本是没有问题的，如果存在z轴则会出现
    /// </summary>
    public class DialogueTrigger2D : MonoBehaviour
    {
        public string ScriptName;

        public string Label;

        private async void OnTriggerEnter2D(Collider2D other)
        {
            var switchToDialogueMode = new SwitchToDialogueMode
            {
                ScriptName = this.ScriptName, Label = this.Label
            };

            await switchToDialogueMode.ExecuteAsync();
        }
    }
}
