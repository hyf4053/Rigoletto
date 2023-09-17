using Naninovel;
using UnityEngine;

namespace NaniNovelHelper.Commands
{
    /// <summary>
    /// todo：未完成
    /// </summary>
    [CommandAlias("dialogue")]
    public class SwitchToDialogueMode : Command
    {
        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            //1. 启用Naninovel的InputManager
            var inputManager = Engine.GetService<IInputManager>();
            inputManager.ProcessInput = true;
            
            //2. todo：禁用玩家的InputManager
            
        }
    }
}
