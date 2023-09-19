using System;
using Cinemachine;
using UnityEngine;

namespace GameFramework.Camera
{
    /// <summary>
    /// 相机的管理类
    /// </summary>
    public class CameraManager : MonoBehaviour
    {
        //场景主相机，一般用于跟随玩家
        public CinemachineVirtualCamera mainVirtualCamera;

        //UI相机
        public UnityEngine.Camera uiCamera;

        private void Start()
        {
            //获取UI相机
            uiCamera = GameObject.FindWithTag("UICamera").GetComponent<UnityEngine.Camera>();
        }

        //如果不是菜单场景，该函数可以用来根据tag“MainVirtualCamera”寻找该场景的相机
        //todo：该方案不够高效和精确，后续继续变更到引用
        public void DisplaceMainCamera()
        {
            if (Singleton.Instance.GameManager.data.CurrentSceneID != 0)
            {
                mainVirtualCamera = GameObject.FindWithTag("MainVirtualCamera").GetComponent<CinemachineVirtualCamera>();
            }
        }

        /// <summary>
        /// 重新绑定相机到目标对象（后续部分角色可能自己的Prefab会包含虚拟相机）
        /// </summary>
        /// <param name="character">相机跟踪对象</param>
        /// <param name="lookAtTransform">相机聚焦的Transform</param>
        /// <param name="cmVirtualCamera">虚拟相机</param>
        public void RebindCharacterToTheCamera(GameObject character, GameObject lookAtTransform,
            CinemachineVirtualCamera cmVirtualCamera)
        {
            //如果传入的相机对象为空，则调用绑定相机的函数，获得此场景的相机引用
            if (cmVirtualCamera == null)
            {
                DisplaceMainCamera();
                
#if UNITY_EDITOR
                //该断言表示，此场景的相机无法被找到
                System.Diagnostics.Debug.Assert(mainVirtualCamera!=null);
#endif
                mainVirtualCamera.Follow = character.transform;
                mainVirtualCamera.LookAt = lookAtTransform.transform;
            }
            else
            {
                cmVirtualCamera.Follow = character.transform;
                cmVirtualCamera.LookAt = lookAtTransform.transform;
            }
            
        }
    }
}
