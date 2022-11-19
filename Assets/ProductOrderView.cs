using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProductOrderView : MonoBehaviour
{
    public SpriteRenderer sprIcon;

    public void Init(SOProduct prod)
    {
        sprIcon.sprite = prod.Icon;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
