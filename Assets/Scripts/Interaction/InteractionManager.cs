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
    IInteractionHover hover;

    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, distance, layers))
        {
            if (hit.transform.TryGetComponent<IInteractionTarget>(out var newTarget))
            {
                if (target != newTarget)
                {
                    hover?.OnHoverExit();

                    target = newTarget;

                    hover = hit.transform.GetComponent<IInteractionHover>();
                    hover?.OnHoverEnter();
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

    private void Clear()
    {
        hover?.OnHoverExit();

        target = null;
        hover = null;
    }
}

public interface IInteractionTarget
{
    public void Interact();
}

public interface IInteractionHover
{
    public void OnHoverEnter();
    public void OnHoverExit();
}
