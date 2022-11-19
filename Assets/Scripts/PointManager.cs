using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance;
    public Single Points { get; private set; } = 0f;
    public Int32 CorrectInRow { get; private set; } = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(Instance);
    }

    private void OnOrderCompleted(ProductKind[] products)
    {
        Single basicPoints = products.Length * 10;
        CorrectInRow += 1;

        //na razie tyle, nikt raczej nie bêdzie gra³ dalej a nie wiadomo czy te pointy w ogóle u¿yjemy
        if (CorrectInRow > 20)
            Points += basicPoints * 3;
        else if (CorrectInRow > 10)
            Points += basicPoints * 2;
        else
            Points += basicPoints;
    }

    private void OnOrderFailed(ProductKind[] products)
    {
        CorrectInRow = 0;
    }
}
