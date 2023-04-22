using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : LoboMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance { get =>  instance; }

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }
    protected override void Awake()
    {
        base.Awake();
        if(GameCtrl.instance != null) Debug.LogError("only 1 InputManager allow to exist");
        GameCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameCtrl.FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

}
