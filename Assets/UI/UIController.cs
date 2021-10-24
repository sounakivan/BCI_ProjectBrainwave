using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image player1;
    [SerializeField] private Image player2;
    [SerializeField] private TMPro.TMP_Text _wait;
    private bool p1In;
    private bool p2In;

    // Start is called before the first frame update
    void Start()
    {
        p1In = false;
        p2In = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            UpdateValue(player1);
            p1In = true;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            UpdateValue(player2);
            p2In = true;
        }

        UpdateStatus(p1In, p2In);

    }

    private void UpdateStatus(bool p1In, bool p2In)
    {
        if ((!p1In && !p2In))
        {
            _wait.SetText("Select the buttons to join");
        }
        if ((p1In && !p2In) || (!p1In && p2In))
        {
            _wait.SetText("Wait for the other player to join...");
        }
        if ((p1In && p2In))
        {
            _wait.SetText("Game On!");
        }
    }

    private void UpdateValue(Image player)
    {
        float duration = 1.0f;
        float barVal = player.fillAmount = 0f;

        DOTween.To(() => barVal, incrementer => barVal = incrementer, 1, duration)
            .OnUpdate(() =>
            {
                float newVal = player.fillAmount;
                newVal = barVal;
                player.fillAmount = newVal;

            }
            );
    }


}
