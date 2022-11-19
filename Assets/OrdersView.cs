using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Product = Assets.Scripts.Product;

public class OrdersView : MonoBehaviour
{
    public GameObject objOneOrderView;

    public Transform trGridParent;

    private List<GameObject> _orderProductViews = new List<GameObject>();

    internal void ShowOrders(Product[] requestedProducts)
    {
        foreach(Product product in requestedProducts)
        {
            GameObject spawned = Instantiate(objOneOrderView, trGridParent);
            //spawned.GetComponent<Order>
            spawned.GetComponent<ProductOrderView>().Init(product);
            _orderProductViews.Add(spawned);
        }

    }

    internal void CompleteOrder()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
