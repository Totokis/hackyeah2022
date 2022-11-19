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

        public SOProduct ProductInHand { get; set; }

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
