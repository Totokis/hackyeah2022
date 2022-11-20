using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private TextMeshProUGUI txtIntro;
    //[SerializeField] private TextMeshProUGUI txtPressToContinue;

    // Start is called before the first frame update
    void Start()
    {
        txtIntro = GetComponent<TextMeshProUGUI>();

        txtIntro.color = new Color(1f, 1f, 1f, 0f);

        LeanTween.value(0f, 1f, 1.5f)
            .setOnUpdate((Single val) =>
            {
                txtIntro.color = new Color(1f, 1f, 1f, val);

            })
            .setOnComplete(() =>
            {

                LeanTween.delayedCall(2.5f, () =>
                {
                    LeanTween.value(1f, 0f, 1.5f)
                                .setOnUpdate((Single val) =>
                                {
                                    txtIntro.color = new Color(1f, 1f, 1f, val);
                                });

                });
                //LeanTween.value(0f, 1f, 1f)
                //    .setOnUpdate((Single val) =>
                //    {
                //        txtPressToContinue.color = new Color(1f, 1f, 1f, val);
                //        LeanTween.value(1f, 0f, 1f)
                //            .setOnUpdate((Single val) =>
                //            {
                //                txtPressToContinue.color = new Color(1f, 1f, 1f, val);
                //            })
                //            .setLoopPingPong();
                //    });
            });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
