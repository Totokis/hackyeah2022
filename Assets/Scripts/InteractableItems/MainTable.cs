using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTable : MonoBehaviour, IInteractionTarget
{
    public List<SOProduct> Products;
    public void Interact()
    {
        if(PlayerManager.Instance.ProductInHand != null)
            PlayerManager.Instance.ProductInHand = null;
    }
}
