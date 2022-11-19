using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOProduct : ScriptableObject
{
    public ProductKind ProductKind;
    public Sprite Icon;
    public GameObject Prefab;
    public String Audio;
}
