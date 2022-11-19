using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngineInternal;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private LayerMask layers;
    [SerializeField] private float distance = 5;

    IInteractionTarget target;
    IInteractionHover[] hovers = new IInteractionHover[0];

    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, distance, layers))
        {
            if (hit.transform.TryGetComponent<IInteractionTarget>(out var newTarget))
            {
                if (target != newTarget)
                {
                    CallOnHoverExit();

                    target = newTarget;

                    hovers = hit.transform.GetComponents<IInteractionHover>();
                    CallOnHoverEnter();
                }

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    target.Interact();
                }
            }
            else
            {
                Clear();
            }
        }
        else
        {
            Clear();
        }
    }

    private void CallOnHoverEnter()
    {
        for (int i = 0; i < hovers.Length; i++)
        {
            hovers[i].OnHoverEnter();
        }
    }

    private void CallOnHoverExit()
    {
        for (int i = 0; i < hovers.Length; i++)
        {
            hovers[i].OnHoverExit();
        }
    }

    private void Clear()
    {
        CallOnHoverExit();

        target = null;
        hovers = new IInteractionHover[0];
    }
}
