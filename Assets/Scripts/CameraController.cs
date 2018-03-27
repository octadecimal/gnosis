using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;

    CinemachineFramingTransposer composer;

    void Start ()
    {
        composer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
	
	void Update ()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            composer.m_CameraDistance += 10;

            if (composer.m_CameraDistance > 80)
            {
                composer.m_CameraDistance = 80;
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            composer.m_CameraDistance -= 10;

            if(composer.m_CameraDistance < 10)
            {
                composer.m_CameraDistance = 10;
            }
        }
	}
}
