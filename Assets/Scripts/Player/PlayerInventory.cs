using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public event System.Action<SOProduct> OnProductInHandsChanged;

    public SOProduct ProductInHands { get; private set; }

    public Transform trItemInHandParent;

    private void Awake()
    {
        Instance = this;
    }

    public void SetProductInHands(SOProduct product)
    {
        ProductInHands = product;
        OnProductInHandsChanged?.Invoke(product);

        GameObject spawned = Instantiate(product.PrefabInHand, trItemInHandParent);
        for (int i = 0; i < spawned.transform.childCount; i++)
        {
            Transform Go = spawned.transform.GetChild(i);
            Go.gameObject.layer = LayerMask.NameToLayer("ItemInHand");
        }

    }
}
