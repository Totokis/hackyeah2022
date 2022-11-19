using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerTapper : MonoBehaviour, IInteractionTarget
{
    [SerializeField] private SOProduct soMug;
    [SerializeField] private SOProduct soBeer;
    public void Interact()
    {
        Debug.Log("Dotkniêto piwo");
    }
}
