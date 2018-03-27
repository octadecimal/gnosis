using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float MinDistance = 10f;
    public float MaxDistance = 80f;
    public float Step = 10f;

    CinemachineFramingTransposer composer;

    void Start ()
    {
        composer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
	
	void Update ()
    {
        float delta = Input.GetAxis("Mouse ScrollWheel");

        if (delta < 0f)
        {
            composer.m_CameraDistance += Step;

            if (composer.m_CameraDistance > MaxDistance)
            {
                composer.m_CameraDistance = MaxDistance;
            }
        }
        else if(delta > 0f)
        {
            composer.m_CameraDistance -= Step;

            if(composer.m_CameraDistance < MinDistance)
            {
                composer.m_CameraDistance = MinDistance;
            }
        }
	}
}
