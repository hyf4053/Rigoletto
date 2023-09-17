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
        public string ScriptName;

        public string Label;

        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            //1. 启用Naninovel的InputManager
            var inputManager = Engine.GetService<IInputManager>();
            inputManager.ProcessInput = true;

            var scriptPlayer = Engine.GetService<IScriptPlayer>();
            scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label).Forget();

            Singleton.Instance.GameManager.ChangeGameModeState(GameModeState.Dialogue);
            //2. todo：禁用玩家的InputManager

        }
    }
}
