using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTable : MonoBehaviour, IInteractionTarget
{
    private List<GameObject> Products = new List<GameObject>();
    private List<SOProduct> SOProducts = new List<SOProduct>();
    public GameObject[] ItemPlaceholders;
    public void Interact()
    {
        if(PlayerManager.Instance.ProductInHand != null && Products.Count < 5)
        {
            PutItemOnTable(PlayerManager.Instance.ProductInHand);
            PlayerManager.Instance.ProductInHand = null;
        }
    }

    private void PutItemOnTable(SOProduct soProduct)
    {
        GameObject newProduct = Instantiate(soProduct.Prefab, new Vector3(0, 0, 0), Quaternion.identity, ItemPlaceholders[Products.Count].transform);
        if (soProduct.Name == "Fish" || soProduct.Name == "FishFull")
        {
            newProduct.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }
        else
        {
            newProduct.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        newProduct.transform.localPosition = new Vector3(0, 0, 0);

        Products.Add(newProduct);
        SOProducts.Add(soProduct);
    }

}
