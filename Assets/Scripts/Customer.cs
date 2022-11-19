using System;
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

        private void Start()
        {
            RequestedProducts = OrderManager.Instance.GetOrder();

            #region TEST
            String logText = "Generated products: ";
            foreach (var product in RequestedProducts)
                logText += $"{product.ToString()} ";
            Debug.Log(logText);
            #endregion TEST
        }

    }
}
