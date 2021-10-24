using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image player1;
    [SerializeField] private Image player2;
    [SerializeField] private TMP_Text waitText;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private Slider slider;

    static public float _rotSpeed;

    private bool p1In;
    private bool p2In;

    // Start is called before the first frame update
    void Start()
    {
        p1In = false;
        p2In = false;
        _rotSpeed = slider.value;

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

        _rotSpeed = slider.value;
        speedText.SetText(_rotSpeed.ToString("0"));

    }


    // Update player join status
    private void UpdateStatus(bool p1In, bool p2In)
    {
        if ((!p1In && !p2In))
        {
            waitText.SetText("Select the buttons to join");
        }
        if ((p1In && !p2In) || (!p1In && p2In))
        {
            waitText.SetText("Wait for the other player to join...");
        }
        if ((p1In && p2In))
        {
            waitText.SetText("Game On!");
            //DOVirtual.DelayedCall(3.0f, () => SceneManager.LoadScene("Level 01", LoadSceneMode.Single));
            StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level 01", LoadSceneMode.Single);
    }

    //Spiral progress bar animation when a user joins
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
