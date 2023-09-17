using System;
using Naninovel;
using NaniNovelHelper.Commands;
using UnityEngine;

namespace NaniNovelHelper
{
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
