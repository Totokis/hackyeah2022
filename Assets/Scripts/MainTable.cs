using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTable : MonoBehaviour, IInteractionTarget
{
    public List<SOProduct> Products;
    public void Interact()
    {
        Debug.Log("Dotkniêto main table");
    }
}
