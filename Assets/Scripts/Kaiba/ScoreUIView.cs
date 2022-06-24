using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIView : MonoBehaviour
{
    [SerializeField]
    GameObject SuccessIcon;
    [SerializeField]
    GameObject FailedIcon;

    [SerializeField]
    GameObject IconPanel;

    public void AddSuccessIcon()
    {
        Instantiate(SuccessIcon, IconPanel.transform);
    }

    public void AddFailedIcon()
    {
        Instantiate(FailedIcon, IconPanel.transform);
    }
    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine(GetComponentsInChildren<Graphic>()));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine(GetComponentsInChildren<Graphic>()));
    }

    IEnumerator FadeOutCoroutine(Graphic[] graphics)
    {
        float t = 0;
        float time = 1;
        while (t < time)
        {
            foreach (var item in graphics)
            {
                item.color = new Color(item.color.r, item.color.g, item.color.b, 1-t);
            }

            t += Time.deltaTime;
            yield return null;
        }

        foreach (var item in graphics)
        {
            item.color = new Color(item.color.r, item.color.g, item.color.b, 0);
        }
    }

    IEnumerator FadeInCoroutine(Graphic[] graphics)
    {
        float t = 0;
        float time = 1;
        while (t < time)
        {
            foreach (var item in graphics)
            {
                item.color = new Color(item.color.r, item.color.g, item.color.b, t);
            }

            t += Time.deltaTime;
            yield return null;
        }

        foreach (var item in graphics)
        {
            item.color = new Color(item.color.r, item.color.g, item.color.b, 1);
        }
    }
}
