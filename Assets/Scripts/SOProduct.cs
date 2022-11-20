using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu()]
public class SOProduct : ScriptableObject
{
    public String Name;
    public GameObject Prefab;
    public GameObject PrefabInHand;
    public String Audio;
}
