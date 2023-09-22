using HutongGames.PlayMaker;
using UnityEngine;

namespace StateActionsExtension
{
    [ActionCategory(ActionCategory.Input)]
    [UnityEngine.Tooltip("GetKey函数，可以触发事件版")]
    public class InputGetKeyEvent : FsmStateAction
    {
        [RequiredField] public FsmEvent onGetKey;
        [RequiredField] public KeyCode ListenKeyCode;


        public override void OnUpdate()
        {
            if (Input.GetKey(ListenKeyCode))
            {
                Fsm.Event(onGetKey);
            }
        }

        public override void Reset()
        {
            onGetKey = null;
        }
    }
}
