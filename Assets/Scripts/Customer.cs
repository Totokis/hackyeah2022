using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Customer : MonoBehaviour
    {
        public Product[] RequestedProducts { get; private set; }

        public Single RemainingTime;

        private void Start()
        {
            RequestedProducts = OrderManager.Instance.GetOrder();
            RemainingTime = 60f;

            StartCoroutine(TimePasses());

            #region TEST
            //String logText = "Generated products: ";
            //foreach (var product in RequestedProducts)
            //    logText += $"{product.ToString()} ";
            //Debug.Log(logText);
            #endregion TEST
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
        }

    }
}
