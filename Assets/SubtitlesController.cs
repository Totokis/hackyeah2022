using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class SubtitlesController : MonoBehaviour
{
    public static SubtitlesController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(Instance);
    }
    public TextMeshProUGUI txtSubtitle;

    // Start is called before the first frame update
    void Start()
    {
        txtSubtitle.color = new Color(1f, 1f, 1f, 0f);
    }

    public void ShowCanYourRepeat()
    {
        string[] canURepeat = new string[]
        {
            "Mo�e pan powt�rzy�?",
            "Czy mo�e pan powt�rzy�?",
            "Mo�na jeszcze raz?",
            "Jeszcze raz co poda�?",
        };

        txtSubtitle.text = canURepeat[Random.Range(0, canURepeat.Length)];

        LeanTween.value(0f, 1f, 1.5f)
                    .setOnUpdate((Single val) =>
                    {
                        txtSubtitle.color = new Color(1f, 1f, 1f, val);
                    })
                    .setOnComplete(() =>
                    {

                        LeanTween.delayedCall(2.5f, () =>
                        {
                            LeanTween.value(1f, 0f, 1.5f)
                                        .setOnUpdate((Single val) =>
                                        {
                                            txtSubtitle.color = new Color(1f, 1f, 1f, val);
                                        });

                        });
                    });

    }

    public void ShowWhatDoYouWant()
    {
        string[] whatDoYouWnt = new string[]
        {
            "Dzie� dobry co poda�?",
            "Witam, co poda�?",
            "Czego pan potrzebuje?",
            "W czym mog� pom�c?",
            "Co poda�?",
        };
        txtSubtitle.text = whatDoYouWnt[Random.Range(0, whatDoYouWnt.Length)];

        LeanTween.value(0f, 1f, 1.5f)
            .setOnUpdate((Single val) =>
            {
                txtSubtitle.color = new Color(1f, 1f, 1f, val);
            })
            .setOnComplete(() =>
            {

                LeanTween.delayedCall(2.5f, () =>
                {
                    LeanTween.value(1f, 0f, 1.5f)
                                .setOnUpdate((Single val) =>
                                {
                                    txtSubtitle.color = new Color(1f, 1f, 1f, val);
                                });

                });
            });

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.Backspace].wasPressedThisFrame)
            ShowCanYourRepeat();
    }
}
