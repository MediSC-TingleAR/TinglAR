﻿/****************************************************************************
* Copyright 2019 Xreal Techonology Limited. All rights reserved.
*                                                                                                                                                          
* This file is part of NRSDK.                                                                                                          
*                                                                                                                                                           
* https://www.xreal.com/        
* 
*****************************************************************************/

using UnityEngine;

namespace NRKernal.NRExamples
{
    public class ChangeModeController : MonoBehaviour
    {
        public GameObject bb;
        private void Start()
        {
            NRSessionManager.Instance.NRHMDPoseTracker.OnModeChanged += (result) =>
            {
                NRDebugger.Info("[ChangeModeController] ChangeMode result:" + result.success);
            };
        }

        public void ChangeTo6Dof()
        {
            bb.SetActive(true);
            NRSessionManager.Instance.NRHMDPoseTracker.ChangeTo6Dof();
        }

        public void ChangeTo3Dof()
        {
            bb.SetActive(false);
            NRSessionManager.Instance.NRHMDPoseTracker.ChangeTo3Dof();
        }

        public void ChangeTo0Dof()
        {
            NRSessionManager.Instance.NRHMDPoseTracker.ChangeTo0Dof();
        }

        public void ChangeTo0DofStable()
        {
            NRSessionManager.Instance.NRHMDPoseTracker.ChangeTo0DofStable();
        }
    }
}
