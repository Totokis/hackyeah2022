using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerTapper : MonoBehaviour, IInteractionTarget
{
    [SerializeField] private SOProduct soMug;
    [SerializeField] private SOProduct soBeer;
    public void Interact()
    {
        Debug.Log("Dotkniêto piwo");
        if (PlayerManager.Instance.ProductInHand == soMug)
            PlayerManager.Instance.ProductInHand = soBeer;
    }
}
