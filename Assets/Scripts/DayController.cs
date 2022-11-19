using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    [SerializeField] private Light light;
    private float _cachedLightValueRotationX;
    private float _cachedLightValueRotationY;

    private void Awake()
    {
        _cachedLightValueRotationX = light.transform.rotation.x;
        _cachedLightValueRotationY= light.transform.rotation.y;
    }
    private void Update()
    {
        
    }
}
