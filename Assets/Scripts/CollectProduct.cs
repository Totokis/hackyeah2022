using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectProduct : MonoBehaviour, IInteractionTarget
{
    [SerializeField] private SOProduct product;

    private bool canInteract = true;
    private Vector3 startScale;


    private void Awake()
    {
        startScale = transform.localScale;
    }

    public void Interact()
    {
        if (!canInteract)
            return;

        canInteract = false;

        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, startScale * 1.2f, 0.1f).setLoopPingPong(1).setOnComplete(() => canInteract = true);

        PlayerInventory.Instance.SetProductInHands(product);
    }
}
