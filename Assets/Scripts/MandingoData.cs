using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "MandingoData", menuName = "MandingoSolutions/MandingoData")]
public class MandingoData : ScriptableObject
{
    public EventReference EventReference => _event;
    public int Duration => _duration;

    [SerializeField] private EventReference _event;
    [SerializeField, Range(100, 5000)] private int _duration = 1000;
}
