using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private HealthBehaviour healthBehaviour;

    void OnEnable()
    {
        healthBehaviour.OnHealthChanged += SetSliderValue;
        healthBehaviour.OnMaxHealthChanged += SetSliderMaxValue;
    }
    void OnDisable()
    {
        healthBehaviour.OnHealthChanged -= SetSliderValue;
        healthBehaviour.OnMaxHealthChanged -= SetSliderMaxValue;
    }

    public void SetSliderValue(float health)
    {
        slider.value = health;
    }
    public void SetSliderMaxValue(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

}
