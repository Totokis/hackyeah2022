using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProductOrderView : MonoBehaviour
{
    public SpriteRenderer sprIcon;

    public Sprite FishIcon;
    public Sprite BeerIcon;

    public void Init(ProductKind prod)
    {
        
        switch(prod)
        {
            case ProductKind.Fish:
                sprIcon.sprite = FishIcon;
                break;
            case ProductKind.Beer:
                sprIcon.sprite = BeerIcon;
                break;
        }


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
