using Actors.Character;
using HutongGames.PlayMaker;
using UnityEngine;

namespace StateActionsExtension
{
    [ActionCategory(ActionCategory.Input)]
    [UnityEngine.Tooltip("接受方向信息的输入，根据规则发出合适的事件进行状态转移")]
    public class InputDirectionEvent : FsmStateAction
    {
        [RequiredField] public FsmVector2 moveVector;
        [RequiredField] public Character2DController controller;
        public FsmEvent onKeyAllReleased;
        
        //四向按钮记录
        public bool forwardPressed,backwardPressed,leftwardPressed,rightwardPressed;
        public bool forwardReleased,backwardReleased,leftwardReleased,rightwardReleased;

        public override void OnEnter()
        {
            if (Input.GetKey(KeyCode.A))
            {
                leftwardPressed = true;
                leftwardReleased = false;
            }

            if (Input.GetKey(KeyCode.D))
            {
                rightwardPressed = true;
                rightwardReleased = false;
            }
            
            if (Input.GetKey(KeyCode.W))
            {
                forwardPressed = true;
                forwardReleased = false;
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                backwardPressed = true;
                backwardReleased = false;
            }
            
            controller.PlayMove();
        }

        public override void OnExit()
        {
            forwardReleased = true;
            backwardReleased = true;
            leftwardReleased = true;
            rightwardReleased = true;

            forwardPressed = false;
            backwardPressed = false;
            leftwardPressed = false;
            rightwardPressed = false;
        }

        public override void Reset()
        {
            moveVector = new FsmVector2 { UseVariable = true };
            onKeyAllReleased = null;
            forwardReleased = true;
            backwardReleased = true;
            leftwardReleased = true;
            rightwardReleased = true;
        }

        public override void OnUpdate()
        {
            float horizontalAxis = 0;
            float verticalAxis = 0;
             if (Input.GetKeyDown(KeyCode.A))
             {
                 //如果不处于移动状态
                 if (Fsm.ActiveStateName!="Move"|| Fsm.ActiveStateName !="Run")
                 {
                     //该函数会尝试改变状态
                     ////TransitionTo(Move);
                     //isIdle = false;
                     //记录按键状态，同时记录按键是否有被释放
                     leftwardPressed = true;
                     leftwardReleased = false;
                    
                     //如果此时对位键有被按下，则表示在按下该键前，对位键已经按下了，此时用变更对位按键的状态
                     if (rightwardPressed)
                     {
                         rightwardPressed = false;
                     }
                 }
                 else
                     //如果已经处于移动状态，则无需改变状态，记录按键状态，同时记录按键是否有被释放
                 if (Fsm.ActiveStateName =="Move" || Fsm.ActiveStateName =="Run")
                 {
                     leftwardPressed = true;
                     leftwardReleased = false;
                    
                     //如果此时对位键有被按下，则表示在按下该键前，对位键已经按下了，此时用变更对位按键的状态
                     if (rightwardPressed)
                     {
                         rightwardPressed = false;
                     }
                 }
                
             }

             if (Input.GetKeyDown(KeyCode.D))
             {
                 if (Fsm.ActiveStateName!="Move"|| Fsm.ActiveStateName !="Run")
                 {
                    // //TransitionTo(Move);
                     //isIdle = false;
                     rightwardPressed = true;
                     rightwardReleased = false;
                 }
                 if (Fsm.ActiveStateName =="Move" || Fsm.ActiveStateName =="Run")
                 {
                     rightwardPressed = true;
                     rightwardReleased = false;
                 }

                 if (leftwardPressed)
                 {
                     leftwardPressed = false;
                 }
             }
            
             if (Input.GetKeyDown(KeyCode.W))
             {
                 if (Fsm.ActiveStateName!="Move"|| Fsm.ActiveStateName !="Run")
                 {
                     ////TransitionTo(Move);
                     //isIdle = false;
                     forwardPressed = true;
                     forwardReleased = false;
                 }
                
                 if (Fsm.ActiveStateName =="Move" || Fsm.ActiveStateName =="Run")
                 {
                     forwardPressed = true;
                     forwardReleased = false;
                 }

                 if (backwardPressed)
                 {
                     backwardPressed = false;
                 }
             }

             if (Input.GetKeyDown(KeyCode.S))
             {
                 if (Fsm.ActiveStateName!="Move"|| Fsm.ActiveStateName !="Run")
                 {
                     //TransitionTo(Move);
                     //isIdle = false;
                     backwardPressed = true;
                     backwardReleased = false;
                 }
                
                 if (Fsm.ActiveStateName =="Move" || Fsm.ActiveStateName =="Run")
                 {
                     backwardPressed = true;
                     backwardReleased = false;
                 }

                 if (forwardPressed)
                 {
                     forwardPressed = false;
                 }
             }
            
             if (Input.GetKeyUp(KeyCode.A))
             {
                 if (Fsm.ActiveStateName =="Move" || Fsm.ActiveStateName =="Run")
                 {
                     if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                     {
                         //TransitionTo(Idle);
                         //isIdle = true;
                     }
                     leftwardPressed = false;
                     leftwardReleased = true;
                    
                     if (!rightwardPressed && !rightwardReleased)
                     {
                         rightwardPressed = true;
                     }
                    
                     if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                     {
                         //TransitionTo(Idle);
                         //isIdle = true;
                     }
                 }
             }
            
             if (Input.GetKeyUp(KeyCode.D))
             {
                 if (Fsm.ActiveStateName =="Move" || Fsm.ActiveStateName =="Run")
                 {
                     if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                     {
                         //TransitionTo(Idle);
                         //isIdle = true;
                     }
                     rightwardPressed = false;
                     rightwardReleased = true;
                    
                     if (!leftwardPressed && !leftwardReleased)
                     {
                         leftwardPressed = true;
                     }
                    
                     if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                     {
                         //TransitionTo(Idle);
                         //isIdle = true;
                     }
                 }
             }
            
             if (Input.GetKeyUp(KeyCode.W))
             {
                 if (Fsm.ActiveStateName =="Move" || Fsm.ActiveStateName =="Run")
                 {
                     if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                     {
                         //TransitionTo(Idle);
                         //isIdle = true;
                     }
                     forwardPressed = false;
                     forwardReleased = true;
                    
                     if (!backwardPressed && !backwardReleased)
                     {
                         backwardPressed = true;
                     }
                    
                     if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                     {
                         //TransitionTo(Idle);
                         //isIdle = true;
                     }
                 }
             }
            
             if (Input.GetKeyUp(KeyCode.S))
             {
                 if (Fsm.ActiveStateName =="Move" || Fsm.ActiveStateName =="Run")
                 {
                     if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                     {
                         //TransitionTo(Idle);
                         //isIdle = true;
                     }
                     backwardPressed = false;
                     backwardReleased = true;
                    
                     if (!forwardPressed && !forwardReleased)
                     {
                         forwardPressed = true;
                     }
                     if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                     {
                         //TransitionTo(Idle);
                         //isIdle = true;
                     }
                 }
             }
             if (rightwardPressed||(!rightwardReleased && leftwardReleased))
             {
                 //controller.MoveRight();
                 horizontalAxis = 1;
             }

             if (leftwardPressed||(!leftwardReleased && rightwardReleased))
             {
                 //controller.MoveLeft();
                 horizontalAxis = -1;
             }
             
             if (forwardPressed||(!forwardReleased && backwardReleased))
             {
                // controller.MoveUp();
                verticalAxis = 1;
             }

             if (backwardPressed||(!backwardReleased && forwardReleased))
             {
                 //controller.MoveDown();
                 verticalAxis = -1;
             }
             
             moveVector.Value = new Vector2(horizontalAxis, verticalAxis);

             if (moveVector.Value.magnitude > 1.0f)
             {
                 moveVector.Value = moveVector.Value.normalized;
             }
            
             controller.Move(moveVector.Value);
            
             if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && 
                 !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
             {
                 Fsm.Event(onKeyAllReleased);
             }
        }
    }
}
