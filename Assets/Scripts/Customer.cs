using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts
{
    public class Customer : MonoBehaviour, INPCReference, IInteractionTarget, IInteractionTargetG
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
                //Orders.ShowOrders(RequestedProducts);

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

            PrintAllOrders();

            List<QuoteType> quotes = new List<QuoteType>();
            quotes.Add(QuoteType.Witanko);
            quotes.Add(QuoteType.Poprosze);
            foreach (SOProduct reqProduct in RequestedProducts)
            {
                switch (reqProduct.Name)
                {
                    case "Fish":
                        quotes.Add(QuoteType.Ryba);
                        break;
                    case "Wine":
                        quotes.Add(QuoteType.Wino);
                        break;
                    case "Beer":
                        quotes.Add(QuoteType.Piwo);
                        break;
                }
            }

            YiellQuotes(quotes.ToArray());
            ;
            //var result = task.Run();
            // StartCoroutine(Annoyed1());
            // StartCoroutine(Annoyed2());
            // StartCoroutine(Annoyed3());
            // StartCoroutine(Annoyed4());
            StartCoroutine(TimePasses());
        }

        public async UniTask YiellQuotes(QuoteType[] quotes)
        {
            foreach (var quote in quotes)
                await NPC.MandingoController.PlayQuote(quote);

            return;
        }

        private void PrintAllOrders()
        {
            foreach (var order in RequestedProducts)
            {
                print($"I want: {order.name}");
            }
        }

        private IEnumerator TimePasses()
        {
            while (RemainingTime > 0f)
            {
                RemainingTime -= 1f;
                yield return new WaitForSeconds(1);
            }

            Task.Run(async () => await YiellQuotes(new QuoteType[] { QuoteType.GdzieMojeZamowienieKurwiu })) ;

            Leave();
        }

        private IEnumerator Annoyed1()
        {
            yield return new WaitForSeconds(15f);
            Task.Run(async () => await YiellQuotes(new QuoteType[] { QuoteType.Eee}));
        }

        private IEnumerator Annoyed2()
        {
            yield return new WaitForSeconds(25f);
            Task.Run(async () => await YiellQuotes(new QuoteType[] { QuoteType.Eee }));
        }

        private IEnumerator Annoyed3()
        {
            yield return new WaitForSeconds(40f);
            Task.Run(async () => await YiellQuotes(new QuoteType[] { QuoteType.GdzieMojeZamowienieKurwiu }));
        }

        private IEnumerator Annoyed4()
        {
            yield return new WaitForSeconds(50f);
            Task.Run(async () => await YiellQuotes(new QuoteType[] { QuoteType.GdzieMojeZamowienieKurwiu }));
        }

        private void Leave()
        {
            Debug.Log("Customer leaves");
            OnFinish.Invoke(false);
        }

        public void OnGotOrder(SOProduct[] products)
        {
            if (products.Length != RequestedProducts.Length)
            {
                Task.Run(async () => await YiellQuotes(new QuoteType[] { QuoteType.GdzieMojeZamowienieKurwiu }));
                OnFinish.Invoke(false);
            }
            else
            {
                foreach (var potentialProduct in AllProducts.Products)
                {
                    if (products.Where(pro => pro == potentialProduct).ToArray().Length != RequestedProducts.Where(pro => pro == potentialProduct).ToArray().Length)
                    {
                        Task.Run(async () => await YiellQuotes(new QuoteType[] { QuoteType.GdzieMojeZamowienieKurwiu }));
                        OnFinish.Invoke(false);
                        return;
                    }
                }

                Task.Run(async () => await YiellQuotes(new QuoteType[] { QuoteType.Dziekowac }));
                OnFinish.Invoke(true);
            }
        }

        public void Init(NPC npc)
        {
            this.NPC = npc;
        }

        public void Interact()
        {
            //tutaj podaje info o tym co chce
        }

        public void InteractG()
        {
            if (OnFinish != null)
            {
                SOProduct[] givenProducts = MainTable.SOProducts.ToArray();
                OnGotOrder(givenProducts);
                MainTable.OnGiveOrder();
            }
            else
                Debug.Log("Customer is not waiting yet!");
        }
    }
}
