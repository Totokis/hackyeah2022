using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBoxes : MonoBehaviour, IInteractionTarget
{
    [SerializeField] private SOProduct soFullFish;
    public void Interact()
    {
        Debug.Log("fishbox touched");
        if (PlayerManager.Instance.ProductInHand == null)
            PlayerManager.Instance.ProductInHand = soFullFish;
    }
}
