using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        private SOProduct _productInHand;
        public SOProduct ProductInHand
        {
            get 
            {
                return _productInHand;
            }
            set
            {
                PlayerInventory.Instance.SetProductInHands(value);
                _productInHand = value;
            }
        }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);

            DontDestroyOnLoad(Instance);
        }
    }
}
