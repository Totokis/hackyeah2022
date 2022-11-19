using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu()]
public class SOProduct : ScriptableObject
{
    public Sprite Icon;
    public GameObject Prefab;
    public String Audio;
}
