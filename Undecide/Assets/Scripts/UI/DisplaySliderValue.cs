using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * ��¥: 2022.05.28
 * �ۼ���: ���ؿ� (Park JunWoo)
 * 
 * Slider ���� ���� �� ������ Text�� ���� �����Ŵ
 */

public class DisplaySliderValue : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderValueText;

    public void SliderValueChanged()
    {
        sliderValueText.text = slider.value.ToString();
    }
}
