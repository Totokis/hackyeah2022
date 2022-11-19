using System;
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
        public SOProduct[] RequestedProducts { get; private set; }
        public SOProductGroup AllProducts { get; private set; }

        private Action<Boolean> OnFinish;

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

        public void OnStartWaiting(Action<Boolean> onFinish)
        {
            OnFinish = onFinish;
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
            OnFinish.Invoke(false);
        }

        public void OnGotOrder(SOProduct[] products)
        {
            if (products.Length != RequestedProducts.Length)
                OnFinish.Invoke(false);
            else
            {
                foreach (var potentialProduct in AllProducts.Products)
                {
                    if (products.Where(pro => pro == potentialProduct).ToArray().Length != RequestedProducts.Where(pro => pro == potentialProduct).ToArray().Length)
                    {
                        OnFinish.Invoke(false);
                        return;
                    }
                }

                OnFinish.Invoke(true);
            }
        }

        public void Init(NPC npc)
        {
            this.NPC = npc;
        }
    }
}
