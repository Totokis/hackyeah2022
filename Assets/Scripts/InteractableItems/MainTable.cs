using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTable : MonoBehaviour, IInteractionTarget//(y)
{
    private static List<GameObject> Products = new List<GameObject>();
    public static List<SOProduct> SOProducts { get; set; } = new List<SOProduct>();
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
        GameObject newProduct = Instantiate(soProduct.Prefab, new Vector3(1000, 1000, 10000), Quaternion.identity, ItemPlaceholders[Products.Count].transform);
        if (soProduct.Name == "Fish" || soProduct.Name == "FishFull")
        {
            newProduct.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }
        else
        {
            newProduct.transform.localScale = new Vector3(1f, 1f, 1f);
            newProduct.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        newProduct.transform.localPosition = new Vector3(0, 0, 0);

        Products.Add(newProduct);
        SOProducts.Add(soProduct);
    }

    public static void OnGiveOrder()
    {
        Products = new List<GameObject>();
        SOProducts = new List<SOProduct>();
        GameObject nonStaticObject = GameObject.Find("Cube.003");
        foreach (var placeholder in nonStaticObject.GetComponent<MainTable>().ItemPlaceholders)
        {
            foreach (Transform child in placeholder.transform)
                Destroy(child.gameObject);
        }
    }
}
