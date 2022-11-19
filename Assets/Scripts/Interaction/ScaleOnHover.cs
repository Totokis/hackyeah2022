using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleOnHover : MonoBehaviour, IInteractionHover
{
    [SerializeField] private Vector3 enterScale;
    [SerializeField] private Vector3 exitScale;

    [Space]
    [SerializeField] private float time = 0.1f;

    public void OnHoverEnter()
    {
        Debug.Log("OnHoverEnter");
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, enterScale, time);
    }

    public void OnHoverExit()
    {
        Debug.Log("OnHoverExit");
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, exitScale, time);
    }
}
