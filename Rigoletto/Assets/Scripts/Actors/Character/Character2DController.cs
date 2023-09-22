using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework;
using UnityEngine;
using UnityEngine.Serialization;

namespace Actors.Character
{
    public class Character2DController : MonoBehaviour
    {
        public Animator characterAnimator;
        public SpriteRenderer SpRenderer;
        public BaseCharacter baseCharacter;
        public float speed;

        public PlayMakerFSM fsm;

        public static readonly int isMove = Animator.StringToHash("isMove");

        /*#region FSM Variables
        
        public bool leftwardPressed;
        public bool rightwardPressed;
        public bool upwardPressed;
        public bool downwardPressed;
        
        public bool leftwardReleased;
        public bool rightwardReleased;
        public bool upwardReleased;
        public bool downwardReleased;
        

        #endregion*/
        
        /*//最终的移动判断
        public void MoveUpdate()
        {
            if (leftwardPressed ||( !leftwardReleased && rightwardReleased))
            {
                MoveLeft();
            }
            if (rightwardPressed ||( !rightwardReleased && leftwardReleased))
            {
                MoveRight();
            }
            if (upwardPressed ||( !upwardReleased && downwardReleased))
            {
                MoveUp();
            }
            if (downwardPressed ||( !downwardReleased && upwardReleased))
            {
                MoveDown();
            }
        }*/

        /*public void InputUpdate()
        {
             if (Input.GetKeyDown(KeyCode.A))
             {
                 //如果不处于移动状态
                 if (fsm.ActiveStateName != "Move")
                 {
                     //该函数会尝试改变状态
                     fsm.SendEvent("OnMoveKeyPressed");
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
                 if (fsm.ActiveStateName == "Move")
                 {
                     //该函数会尝试改变状态到中间态，用于播放对应的移动动画
                     //fsm.SendEvent("OnMoveKeyPressed");
                    
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
                 if (fsm.ActiveStateName != "Move")
                 {
                     fsm.SendEvent("OnMoveKeyPressed");
                     //isIdle = false;
                     rightwardPressed = true;
                     rightwardReleased = false;
                 }
                 if (fsm.ActiveStateName == "Move")
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
                 if (fsm.ActiveStateName != "Move")
                 {
                     fsm.SendEvent("OnMoveKeyPressed");
                     //isIdle = false;
                     upwardPressed = true;
                     upwardReleased = false;
                 }
                
                 if (fsm.ActiveStateName == "Move")
                 {
                     upwardPressed = true;
                     upwardReleased = false;
                 }

                 if (downwardPressed)
                 {
                     downwardPressed = false;
                 }
             }

             if (Input.GetKeyDown(KeyCode.S))
             {
                 if (fsm.ActiveStateName != "Move")
                 {
                     fsm.SendEvent("OnMoveKeyPressed");
                     //isIdle = false;
                     downwardPressed = true;
                     downwardReleased = false;
                 }
                
                 if (fsm.ActiveStateName == "Move")
                 {
                     downwardPressed = true;
                     downwardReleased = false;
                 }

                 if (upwardPressed)
                 {
                     upwardPressed = false;
                 }
             }
            
             if (Input.GetKeyUp(KeyCode.A))
             {
                 if (fsm.ActiveStateName != "Move")
                 {
                     if (!leftwardPressed && !rightwardPressed && !upwardPressed && !downwardPressed)
                     {
                         fsm.SendEvent("ToIdle");
                         // isIdle = true;
                     }
                     leftwardPressed = false;
                     leftwardReleased = true;
                    
                     if (!rightwardPressed && !rightwardReleased)
                     {
                         rightwardPressed = true;
                     }
                    
                     if (!leftwardPressed && !rightwardPressed && !upwardPressed && !downwardPressed)
                     {
                         fsm.SendEvent("ToIdle");
                         //isIdle = true;
                     }
                 }
             }
            
             if (Input.GetKeyUp(KeyCode.D))
             {
                 if (fsm.ActiveStateName != "Move")
                 {
                     if (!leftwardPressed && !rightwardPressed && !upwardPressed && !downwardPressed)
                     {
                         fsm.SendEvent("ToIdle");
                         // isIdle = true;
                     }
                     rightwardPressed = false;
                     rightwardReleased = true;
                    
                     if (!leftwardPressed && !leftwardReleased)
                     {
                         leftwardPressed = true;
                     }
                    
                     if (!leftwardPressed && !rightwardPressed && !upwardPressed && !downwardPressed)
                     {
                         fsm.SendEvent("ToIdle");
                         //isIdle = true;
                     }
                 }
             }
            
             if (Input.GetKeyUp(KeyCode.W))
             {
                 if (fsm.ActiveStateName != "Move")
                 {
                     if (!leftwardPressed && !rightwardPressed && !upwardPressed && !downwardPressed)
                     {
                         fsm.SendEvent("ToIdle");
                         // isIdle = true;
                     }
                     upwardPressed = false;
                     upwardReleased = true;
                    
                     if (!downwardPressed && !downwardReleased)
                     {
                         downwardPressed = true;
                     }
                    
                     if (!leftwardPressed && !rightwardPressed && !upwardPressed && !downwardPressed)
                     {
                         fsm.SendEvent("ToIdle");
                         //isIdle = true;
                     }
                 }
             }
            
             if (Input.GetKeyUp(KeyCode.S))
             {
                 if (fsm.ActiveStateName != "Move")
                 {
                     if (!leftwardPressed && !rightwardPressed && !upwardPressed && !downwardPressed)
                     {
                         fsm.SendEvent("ToIdle");
                         //isIdle = true;
                     }
                     downwardPressed = false;
                     downwardReleased = true;
                    
                     if (!upwardPressed && !upwardReleased)
                     {
                         upwardPressed = true;
                     }
                     if (!leftwardPressed && !rightwardPressed && !upwardPressed && !downwardPressed)
                     {
                         fsm.SendEvent("ToIdle");
                         // isIdle = true;
                     }
                 }
             }
        }*/
        
        /*public void OnLeftKeyPressed()
        {
            if (fsm.ActiveStateName != "Move")
            {
                fsm.SendEvent("OnLeftKeyPressed");
                
            }
        }*/
        
        

        // Start is called before the first frame update
        void Start()
        {
            baseCharacter = GetComponentInChildren<BaseCharacter>();
            /*leftwardReleased = true;
            rightwardReleased = true;
            upwardReleased = true;
            downwardReleased = true;

            /*leftwardPressed = fsm.FsmVariables.GetFsmBool("LeftKeyPressed").Value;
            rightwardPressed = fsm.FsmVariables.GetFsmBool("RightKeyPressed").Value;
            upwardPressed = fsm.FsmVariables.GetFsmBool("UpKeyPressed").Value;
            downwardPressed = fsm.FsmVariables.GetFsmBool("DownKeyPressed").Value;

            leftwardReleased =fsm.FsmVariables.GetFsmBool("LeftKeyReleased").Value;
            rightwardReleased =fsm.FsmVariables.GetFsmBool("RightKeyReleased").Value;
            upwardReleased =fsm.FsmVariables.GetFsmBool("UpKeyReleased").Value;
            downwardReleased = fsm.FsmVariables.GetFsmBool("DownKeyReleased").Value;#1#

            // fsm.*/
        }


        private void Update()
        {
            
        }


        public void ResetAnimation()
        {
            characterAnimator.SetBool(isMove,false);
        }

        /*public void MoveLeft()
        {
            characterAnimator.SetBool(isMove,true);
            SpRenderer.flipX = true;
            transform.position += new Vector3(-speed, 0, 0);
        }

        public void MoveRight()
        {
            characterAnimator.SetBool(isMove,true);
            SpRenderer.flipX = false;
            transform.position += new Vector3(speed, 0, 0);
        }

        public void MoveUp()
        {
            characterAnimator.SetBool(isMove,true);
            transform.position += new Vector3(0, 0, speed);
        }

        public void MoveDown()
        {
            characterAnimator.SetBool(isMove,true);
            transform.position += new Vector3(0, 0, -speed);
        }*/

        public void Move(Vector2 normalizedVector)
        {
            if (normalizedVector.x < 0)
            {
                SpRenderer.flipX = true;
            }else if (normalizedVector.x > 0)
            {
                SpRenderer.flipX = false;
            }

            transform.position += new Vector3(normalizedVector.x,0,normalizedVector.y) * speed;
        }

        public IEnumerator Jump(Vector2 normalizedVector)
        {
            float t = 0f;
            while (t < 0.5f)
            {
                t += Time.deltaTime;
                if (normalizedVector.x < 0)
                {
                    SpRenderer.flipX = true;
                }else if (normalizedVector.x > 0)
                {
                    SpRenderer.flipX = false;
                }

                transform.position += new Vector3(normalizedVector.x,1f+Time.deltaTime,normalizedVector.y) * speed;
                yield return null;
            }
        }

        public void PlayMove()
        {
            characterAnimator.SetBool(isMove,true);
        }
        
        
    }
}
