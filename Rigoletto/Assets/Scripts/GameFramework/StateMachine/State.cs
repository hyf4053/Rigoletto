using System.Collections.Generic;
using UnityEngine;

namespace GameFramework.StateMachine
{
    [CreateAssetMenu(fileName = "New State", menuName = "ScriptableObjects/StateMachine/New State", order = 1)]
    public class State : ScriptableObject
    {
        //状态ID
        public string stateID;
        //状态可读名
        public string stateName;
        
        //特殊State- Any State
        public bool isAnyState;
        
        //该状态可以过渡到哪个状态
        public List<State> statesCanTransitTo;
    }
}
