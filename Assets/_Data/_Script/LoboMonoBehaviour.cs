using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboMonoBehaviour : MonoBehaviour
{
    
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
        //this.LoadComponents();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        //For override
    }
    protected virtual void ResetValue()
    {
        //For override
    }
    protected virtual void OnEnable()
    {
        //For override
    }
    protected virtual void Start()
    {
        //For override
    }

}
