using System;
using Cinemachine;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 相机的管理类
    /// </summary>
    public class CameraManager : MonoBehaviour
    {
        //场景主相机，一般用于跟随玩家
        public CinemachineVirtualCamera mainVirtualCamera;

        private void Awake()
        {
            //根据Tag自动分配当前场景中的主相机
            //RedisplacementMainCamera();
        }

        public void RedisplaceMainCamera()
        {
            if (Singleton.Instance.GameManager.Data.CurrentSceneID != 0)
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
            if (cmVirtualCamera == null)
            {
                RedisplaceMainCamera();
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
