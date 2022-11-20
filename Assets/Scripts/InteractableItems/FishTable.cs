using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTable : MonoBehaviour, IInteractionTarget
{
    [SerializeField] private SOProduct soFullFish;
    [SerializeField] private SOProduct soFish;
    public void Interact()
    {
        if (PlayerManager.Instance.ProductInHand == soFullFish)
            PlayerManager.Instance.ProductInHand = soFish;
    }
}
