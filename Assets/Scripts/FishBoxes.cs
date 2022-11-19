using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBoxes : MonoBehaviour, IInteractionTarget
{
    public void Interact()
    {
        Debug.Log("fishbox touched");
    }
}
