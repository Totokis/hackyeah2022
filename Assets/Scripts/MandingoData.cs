using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "MandingoData", menuName = "MandingoSolutions/MandingoData")]
public class MandingoData : ScriptableObject
{
    [SerializeField] private EventReference _event;
    [SerializeField, Range(100, 5000)] private int _duration = 1000;
}
