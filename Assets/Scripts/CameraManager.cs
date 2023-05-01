using UnityEngine;
using System;
using Cinemachine;
using System.Collections.Generic;

public class CameraManager : Singleton<CameraManager>
{

    public CinemachineVirtualCamera liveCam = null;

    public List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public void AddCamera(CinemachineVirtualCamera targetCam)
    {
        if (!CheckForDuplicates(targetCam))
            cameras.Add(targetCam);
    }



    public void SetLive(String targetCam)
    {
        if (targetCam != null)
        {
            foreach (var cam in cameras)
            {
                if (cam.name == targetCam)
                {
                    cam.gameObject.SetActive(true);
                    //Set active cam to live 
                    liveCam = cam.GetComponent<CinemachineVirtualCamera>();
                    liveCam.m_Priority = 10;
                }
                else
                {
                    //If not active gamestate - disable camera and canvas
                    cam.gameObject.SetActive(false);
                    cam.GetComponent<CinemachineVirtualCamera>().m_Priority = 0;
                }
            }
        }
    }

    public void SetLive(CinemachineVirtualCamera targetCam)
    {
        if (targetCam != null)
        {
            foreach (var cam in cameras)
            {
                if (cam == targetCam)
                {
                    //Set active cam to live 
                    liveCam = cam.GetComponent<CinemachineVirtualCamera>();
                    liveCam.m_Priority = 10;
                }
                else
                {
                    //If not active gamestate - disable camera and canvas
                    cam.GetComponent<CinemachineVirtualCamera>().m_Priority = 0;
                }
            }
        }
    }

    public void AssignFollowTarget(Transform target)
    {
        //liveCam.m_Follow = target;
        liveCam.Follow = target;
    }

    public void AssignLookAtTarget(Transform target)
    {
        //liveCam.m_LookAt = target;
        liveCam.LookAt = target;
    }

    public bool CheckForDuplicates(CinemachineVirtualCamera targetCam)
    {
        if (targetCam != null)
        {
            foreach (var cam in cameras)
            {
                if (cam.name == targetCam.name)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
