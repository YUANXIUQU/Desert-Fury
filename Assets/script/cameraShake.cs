using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    public static CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    private float timer;
    private void Awake()
    {
        cinemachineVirtualCamera =  GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float time)
    { 
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        timer = time;
    }

    private void Update()
    {
        if(timer > 0)
        {
            // camera shakes
            timer -= Time.deltaTime;
            if(timer <= 0) // time over, so camera stops shaking
            {
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
            }
        }
    }
}
