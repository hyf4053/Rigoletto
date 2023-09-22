using System;
using System.Collections.Generic;
using Actors.Character;
using UnityEngine;

namespace GameFramework.StateMachine
{
    /// <summary>
    /// 角色状态机
    /// 1.角色初始状态为Idle
    /// 2.当玩家按下任意键的时候，会通过事件把对应按键的消息传达到状态机中
    /// 3.根据消息，结合当前的状态机状态，过度到对应状态中去
    ///
    /// 比如：
    /// 1.玩家按下W键
    /// 2.检查当前状态
    /// 3.比如是Idle，那么isIdle调整为false，然后调用TransitionTo(Move,leftwardPressed).
    /// 4.此时的状是Move，然后
    /// </summary>
    public class CharacterStateMachine : StateMachine
    {
        #region Idle State
        public State Idle;
        public bool isIdle;
        public Character2DController controller;
        
        #endregion
        
        #region Move State

        public State Move;
        //四向按钮记录
        public bool forwardPressed,backwardPressed,leftwardPressed,rightwardPressed;
        public bool forwardReleased,backwardReleased,leftwardReleased,rightwardReleased;
        //记录最近的四次按键
        public List<KeyCode> inputRecord;
        
        #endregion
        
        

        public DebugHelper.DebugHelper h;

        private void Start()
        {
            currentState = Idle;
            isIdle = true;
            forwardReleased = true;
            backwardReleased = true;
            leftwardReleased = true;
            rightwardReleased = true;
        }
        
        

        /*private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                inputRecord.Add(KeyCode.A);
                
                //如果不处于移动状态
                if (currentState != Move)
                {
                    //该函数会尝试改变状态
                    TransitionTo(Move);
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
                if (currentState == Move)
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
                inputRecord.Add(KeyCode.D);
                if (currentState != Move)
                {
                    TransitionTo(Move);
                    isIdle = false;
                    rightwardPressed = true;
                    rightwardReleased = false;
                }
                if (currentState == Move)
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
                inputRecord.Add(KeyCode.W);
                if (currentState != Move)
                {
                    TransitionTo(Move);
                    isIdle = false;
                    forwardPressed = true;
                    forwardReleased = false;
                }
                
                if (currentState == Move)
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
                inputRecord.Add(KeyCode.S);
                if (currentState != Move)
                {
                    TransitionTo(Move);
                    isIdle = false;
                    backwardPressed = true;
                    backwardReleased = false;
                }
                
                if (currentState == Move)
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
                if (currentState == Move)
                {
                    if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                    {
                        TransitionTo(Idle);
                        isIdle = true;
                    }
                    leftwardPressed = false;
                    leftwardReleased = true;
                    
                    if (!rightwardPressed && !rightwardReleased)
                    {
                        rightwardPressed = true;
                    }
                    
                    if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                    {
                        TransitionTo(Idle);
                        isIdle = true;
                    }
                }
            }
            
            if (Input.GetKeyUp(KeyCode.D))
            {
                if (currentState == Move)
                {
                    if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                    {
                        TransitionTo(Idle);
                        isIdle = true;
                    }
                    rightwardPressed = false;
                    rightwardReleased = true;
                    
                    if (!leftwardPressed && !leftwardReleased)
                    {
                        leftwardPressed = true;
                    }
                    
                    if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                    {
                        TransitionTo(Idle);
                        isIdle = true;
                    }
                }
            }
            
            if (Input.GetKeyUp(KeyCode.W))
            {
                if (currentState == Move)
                {
                    if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                    {
                        TransitionTo(Idle);
                        isIdle = true;
                    }
                    forwardPressed = false;
                    forwardReleased = true;
                    
                    if (!backwardPressed && !backwardReleased)
                    {
                        backwardPressed = true;
                    }
                    
                    if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                    {
                        TransitionTo(Idle);
                        isIdle = true;
                    }
                }
            }
            
            if (Input.GetKeyUp(KeyCode.S))
            {
                if (currentState == Move)
                {
                    if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                    {
                        TransitionTo(Idle);
                        isIdle = true;
                    }
                    backwardPressed = false;
                    backwardReleased = true;
                    
                    if (!forwardPressed && !forwardReleased)
                    {
                        forwardPressed = true;
                    }
                    if (!leftwardPressed && !rightwardPressed && !forwardPressed && !backwardPressed)
                    {
                        TransitionTo(Idle);
                        isIdle = true;
                    }
                }
            }

            if (forwardPressed||(!forwardReleased && backwardReleased))
            {
                controller.MoveUp();
            }

            if (backwardPressed||(!backwardReleased && forwardReleased))
            {
                controller.MoveDown();
            }

            if (rightwardPressed||(!rightwardReleased && leftwardReleased))
            {
                controller.MoveRight();
            }

            if (leftwardPressed||(!leftwardReleased && rightwardReleased))
            {
                controller.MoveLeft();
            }
            #region Debug Display

            if (backwardReleased)
            {
                h.SR();
            }

            if (backwardPressed)
            {
                h.SPress();
            }
            
            if (forwardReleased)
            {
                h.WR();
            }

            if (forwardPressed)
            {
                h.WPress();
            }
            
            if (leftwardReleased)
            {
                h.AR();
            }

            if (leftwardPressed)
            {
                h.APress();
            }
            
            if (rightwardReleased)
            {
                h.DR();
            }

            if (rightwardPressed)
            {
                h.DPress();
            }

            #endregion
        }*/


        
        public override void TransitionTo(State targetState)
        {
            //检验当前状态，是否可以转变到目标状态
            if (currentState.statesCanTransitTo.Contains(targetState))
            {
                prevState = currentState;
                OnStateExit();
                currentState = targetState;
                OnStateEnter();
            }
            else
            {
                return;
            }
            //能运行到这里证明状态已经切换完成
            if (targetState == Move)
            {
                isIdle = false;
            }

            if (targetState == Idle)
            {
                controller.ResetAnimation();
                leftwardPressed = false;
                rightwardPressed = false;
                forwardPressed = false;
                backwardPressed = false;
            }
        }

        protected override void OnStateEnter()
        {
            base.OnStateEnter();
        }

        protected override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}
