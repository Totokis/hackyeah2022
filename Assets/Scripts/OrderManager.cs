using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    public Single MaxItemsPerCustomer = 5f;
    public Single MinItemsPerCustomer = 1f;
    public Single DifficultyRaiseSpeed = 0.1f;

    private static OrderManager _instance = null;
    public static OrderManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new OrderManager();
            return _instance;
        }
    }

    public void Start()
    {
        #region TEST

        #endregion TEST
    }

    public Product[] GetOrder()
    {
        List<Product> products = new List<Product>();

        //losuje iloœæ itemków
        Int32 numberOfItems = Convert.ToInt32(Random.Range(MinItemsPerCustomer, MaxItemsPerCustomer));
        if (MinItemsPerCustomer < MaxItemsPerCustomer - 1)
            MinItemsPerCustomer += DifficultyRaiseSpeed;

        //losuje konkretne taski
        for (int i = 0; i < numberOfItems; i++)
        {
            Product[] allProducts = (Product[])Enum.GetValues(typeof(Product));
            Int32 randomedItemIndex = Random.Range(0, allProducts.Length);
            Product newProduct = allProducts[randomedItemIndex];
            products.Add(newProduct);
        }

        return products.ToArray();
    }
}
