using UnityEngine;

namespace Actors.Character
{
    public class MainCharacter : BaseCharacter
    {
        //重载DataInit
        public override void DataInit()
        {
            
            base.DataInit();
        }

        // Start is called before the first frame update
        void Start()
        {
            DataInit();
            //Debug.Log(data
            //Predefined.characterID);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}