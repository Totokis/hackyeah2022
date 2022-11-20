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
        Debug.Log("Dotkniêto fisztable");
        if (PlayerManager.Instance.ProductInHand == soFullFish)
        {
            Debug.Log("Full fish");
            PlayerManager.Instance.ProductInHand = soFish;
        }
        else
            Debug.Log("Not full fish");
    }
}
