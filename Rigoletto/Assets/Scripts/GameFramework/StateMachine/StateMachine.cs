using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameFramework.StateMachine
{
    /// <summary>
    /// 通用状态机
    /// </summary>
    public class StateMachine : MonoBehaviour
    {
        [Header("Events")]
        public UnityEvent onStateEnter;
        [Header("Events")]
        public UnityEvent onStateExit;

        //状态机默认初始状态
        public State initState;

        //状态机当前状态之前的状态（即刚刚是从哪个状态过来的）
        public State prevState;
        
        //状态机当前状态
        public State currentState;

        protected virtual void OnStateEnter()
        {
            onStateEnter.Invoke();
        }

        protected virtual void OnStateExit()
        {
            onStateExit.Invoke();
        }

        public virtual void TransitionTo(State targetState)
        {
            
        }
    }
}
