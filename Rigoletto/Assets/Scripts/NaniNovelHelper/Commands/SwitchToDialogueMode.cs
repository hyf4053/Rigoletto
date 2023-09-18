using GameFramework;
using Naninovel;
using UnityEngine;

namespace NaniNovelHelper.Commands
{
    /// <summary>
    /// 切换到Dialogue模式
    /// </summary>
    [CommandAlias("dialogue")]
    public class SwitchToDialogueMode : Command
    {
        [ParameterAlias("reset")] public BooleanParameter ResetState = false;
        public string ScriptName;

        public string Label;

        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            //1. 启用Naninovel的InputManager
            var inputManager = Engine.GetService<IInputManager>();
            inputManager.ProcessInput = true;

            //2. 使用Script Player开始播放Nani脚本
            var scriptPlayer = Engine.GetService<IScriptPlayer>();
            scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label).Forget();
            
            //3. 重置对话状态（可选项）
            if (ResetState)
            {
                var stateManager = Engine.GetService<IStateManager>();
                await stateManager.ResetStateAsync();
            }

            Singleton.Instance.GameManager.ChangeGameModeState(GameModeState.Dialogue);
        }
    }
}
