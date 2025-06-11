using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cam
{
    main,
    sub,
    death,
}

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private CinemachineVirtualCamera mainCam;
    [SerializeField] private CinemachineVirtualCamera subCam;
    [SerializeField] private CinemachineVirtualCamera deathCam;

    public void ChangeCam(Cam cam)
    {
        mainCam.Priority = (cam == Cam.main) ? 20 : 5;
		subCam.Priority = (cam == Cam.sub) ? 20 : 5;
		deathCam.Priority = (cam == Cam.death) ? 20 : 5;
	}
}
