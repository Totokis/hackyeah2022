using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTable : MonoBehaviour, IInteractionTarget
{
    [SerializeField] private SOProduct soFullFish;
    [SerializeField] private SOProduct soFish;
    public void Interact()
    {
        Debug.Log("Dotkniêto fisztable");
    }
}
