using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    [SerializeField] private float dayValue;
    [Space]
    [SerializeField] private float lightTargetRotationY;
    [SerializeField] private float lightTargetRotationX;
    [SerializeField] private float skyboxRotationTargetValue;
    [SerializeField] private Light light;
    [SerializeField] private Material skybox;
    
    private float _cachedLightValueRotationX;
    private float _cachedLightValueRotationY;
    private float _cachedSkyboxRotation;

    private void Awake()
    {
        _cachedLightValueRotationX = light.transform.eulerAngles.x;
        _cachedLightValueRotationY= light.transform.eulerAngles.y;
        _cachedSkyboxRotation = skybox.GetFloat("_Rotation");
    }
    private void Update()
    {
        var x = Mathf.Clamp(dayValue, lightTargetRotationX,_cachedLightValueRotationX);
        var y = Mathf.Clamp(dayValue,lightTargetRotationY, _cachedLightValueRotationY );
        var skyboxRotation = Mathf.Clamp(dayValue, skyboxRotationTargetValue,_cachedSkyboxRotation );
        
        light.transform.rotation = Quaternion.Euler(x,y,light.transform.eulerAngles.z);
        skybox.SetFloat("_Rotation",skyboxRotation);
        
    }
}
