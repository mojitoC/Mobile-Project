using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * 날짜: 2022.05.28
 * 작성자: 박준우 (Park JunWoo)
 * 
 * Slider 값이 변경 될 때마다 Text의 값을 변경시킴
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
