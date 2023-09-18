using UnityEngine;

namespace GameFramework.UI
{
    public class LoadingUI : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(this);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
