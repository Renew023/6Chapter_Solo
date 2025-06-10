using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private CinemachineVirtualCamera mainCam;
    [SerializeField] private CinemachineVirtualCamera subCam;

    public void SubCamOn()
    {
        subCam.Priority = 20;
    }

    public void SubCamOff()
    {
        subCam.Priority = 5;
    }
}
