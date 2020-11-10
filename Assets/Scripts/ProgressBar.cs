using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Image bar;

    void Start()
    {
        bar = GetComponent<Image>();
    }

    public void setProgress(float percentageFilled)
    {
        bar.fillAmount = percentageFilled;
    }

    public void resetProgress()
    {
        bar.fillAmount = 0;
    }
}
