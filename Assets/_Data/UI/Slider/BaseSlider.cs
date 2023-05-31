using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : LoboMonoBehaviour
{
    [Header("Base Slider")]
    [SerializeField] protected Slider Slider;
    protected override void Start()
    {
        base.Start();
        this.AddOnclickEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }
    protected virtual void FixedUpdate()
    {
        //For override
    }
    protected virtual void LoadSlider()
    {
        if (this.Slider != null) return;
        this.Slider = GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": LoadSlider", gameObject);
    }
    protected virtual void AddOnclickEvent()
    {
        this.Slider.onValueChanged.AddListener(this.OnChanged);
    }
    protected abstract void OnChanged(float newValue);
}
