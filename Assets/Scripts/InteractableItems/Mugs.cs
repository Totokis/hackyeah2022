using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mugs : MonoBehaviour, IInteractionTarget
{
    [SerializeField] private SOProduct soMug;
    public void Interact()
    {
        if (PlayerManager.Instance.ProductInHand == null)
            PlayerManager.Instance.ProductInHand = soMug;
    }
}
