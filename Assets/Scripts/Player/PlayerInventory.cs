using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public event System.Action<SOProduct> OnProductInHandsChanged;

    public SOProduct ProductInHands { get; private set; }
    public GameObject ProductInScene { get; private set; }

    public Transform trItemInHandParent;

    private void Awake()
    {
        Instance = this;
    }

    public void SetProductInHands(SOProduct product)
    {
        if (ProductInScene != null)
        {
            Destroy(ProductInScene);
            ProductInScene = null;
        }

        ProductInHands = product;
        OnProductInHandsChanged?.Invoke(product);

        if (ProductInHands != null)
        {
            ProductInScene = Instantiate(product.PrefabInHand, trItemInHandParent);

            for (int i = 0; i < ProductInScene.transform.childCount; i++)
            {
                Transform Go = ProductInScene.transform.GetChild(i);
                Go.gameObject.layer = LayerMask.NameToLayer("ItemInHand");
            }
        }
    }
}
