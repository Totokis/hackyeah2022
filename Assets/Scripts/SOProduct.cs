using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SOProduct : ScriptableObject
{
    public ProductKind ProductKind;
    public Sprite Icon;
    public GameObject Prefab;
    public String Audio;

    [MenuItem("Assets/Create/SOProduct")]
    public static void CreateMyAsset()
    {
        SOProduct asset = ScriptableObject.CreateInstance<SOProduct>();

        AssetDatabase.CreateAsset(asset, "Assets/SOProduct.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
