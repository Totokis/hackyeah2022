﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Customer : MonoBehaviour, INPCReference
    {
        public ProductKind[] RequestedProducts { get; private set; }

        public OrdersView Orders;

        public NPC NPC;

        public Single RemainingTime;

        private void Start()
        {
            RequestedProducts = OrderManager.Instance.GetOrder();
            Orders.ShowOrders(RequestedProducts);

            RemainingTime = 60f;

            #region TEST
            //String logText = "Generated products: ";
            //foreach (var product in RequestedProducts)
            //    logText += $"{product.ToString()} ";
            //Debug.Log(logText);
            #endregion TEST
        }

        public  void OnStartWaiting()
        {
            StartCoroutine(TimePasses());
        }

        private IEnumerator TimePasses()
        {
            while (RemainingTime > 0f)
            {
                RemainingTime -= 1f;
                yield return new WaitForSeconds(1);
            }

            Leave();
        }

        private void Leave()
        {
            Debug.Log("Customer leaves");
            NPC.CustomerFinished(false);
        }

        private void OnGotOrder(ProductKind[] products)
        {
            if(products.Length != RequestedProducts.Length)
                NPC.CustomerFinished(false);
            else
            {
                ProductKind[] allProducts = (ProductKind[])Enum.GetValues(typeof(ProductKind));

                foreach(var potentialProduct in allProducts)
                {
                    if(products.Where(pro => pro == potentialProduct).ToArray().Length != RequestedProducts.Where(pro => pro == potentialProduct).ToArray().Length)
                    {
                        NPC.CustomerFinished(false);
                        return;
                    }
                }

                NPC.CustomerFinished(true);
            }
        }

        public void Init(NPC npc)
        {
            this.NPC = npc;
        }
    }
}
