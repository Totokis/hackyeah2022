using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleInteraction : MonoBehaviour, IInteractionTarget, IInteractionHover
{
    private bool canInteract = true;

    public void Interact()
    {
        if (!canInteract)
            return;

        canInteract = false;

        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector3.one * 1.2f, 0.1f).setLoopPingPong(1).setOnComplete(() => canInteract = true);
    }

    public void OnHoverEnter()
    {

    }

    public void OnHoverExit()
    {
        canInteract = true;
    }
}
