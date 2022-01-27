using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class screenEffects : MonoBehaviour
{
    [Header("Camera shake")]
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;
    [Header("Screen flash")]
    public Animator screenFlashAnimator;
    public string screenFlashTrigger;
    public static screenEffects Instance { get; private set; }

    [Header("camara options")]
    public float defultOrthographic = 10f;
    private void Awake()
    {
        Instance = this;
    }
    public void ScreenFlash()
    {
        screenFlashAnimator.SetTrigger(screenFlashTrigger);
    }
    public void ShakeCamera(float intensity,float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
        startingIntensity = intensity;
        shakeTimerTotal = time;
    }
    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity,0f,(1-(shakeTimer/shakeTimerTotal)));
            }
        }
    }
}
