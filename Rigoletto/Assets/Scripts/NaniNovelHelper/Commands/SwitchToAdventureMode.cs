using Naninovel;
using Naninovel.Commands;
using UnityEngine;

namespace NaniNovelHelper.Commands
{
    /// <summary>
    /// Nani Script 可调用函数
    /// 用于从其他状态切换到冒险状态
    /// Example:    @adventure reset:false
    /// </summary>
    [CommandAlias("adventure")]
    public class SwitchToAdventureMode : Command
    {
        [ParameterAlias("reset")] public BooleanParameter ResetState = true;
        
        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            //1. 禁用Naninovel的InputManager
            var inputManager = Engine.GetService<IInputManager>();
            inputManager.ProcessInput = false;
            
            //2. 禁用Nani脚本播放器
            var scriptPlayer = Engine.GetService<IScriptPlayer>();
            scriptPlayer.Stop();
            
            //3. 隐藏对话显示器
            var hidePrinter = new HidePrinter();
            hidePrinter.ExecuteAsync(asyncToken).Forget();
            
            //4. 重置对话状态（可选项）
            if (ResetState)
            {
                var stateManager = Engine.GetService<IStateManager>();
                await stateManager.ResetStateAsync();
            }
            
            //5. 切换到Adv镜头
            var advCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            advCamera.enabled = true;
            var naniCamera = Engine.GetService<ICameraManager>().Camera;
            naniCamera.enabled = false;
            
            //6. 启用玩家InputManager
            // var PlayerController = Object.FindObjectOfType<Stand>


            //throw new System.NotImplementedException();
        }
    }
}
