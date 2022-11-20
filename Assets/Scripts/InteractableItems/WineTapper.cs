using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineTapper : MonoBehaviour, IInteractionTarget
{
    [SerializeField] private SOProduct soMug;
    [SerializeField] private SOProduct soWine;
    public void Interact()
    {
        if (PlayerManager.Instance.ProductInHand == soMug)
            PlayerManager.Instance.ProductInHand = soWine;
    }
}
