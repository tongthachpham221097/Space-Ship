using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : LoboMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    public ShootableObjectCtrl ShootableObjectCtrl => shootableObjectCtrl;

    [SerializeField] protected SlideHp slideHp;
    public SlideHp SlideHp => slideHp;

    [SerializeField] protected FollowTarget followTarget;
    public FollowTarget FollowTarget => followTarget;

    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHp();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }
    protected virtual void LoadSliderHp()
    {
        if (this.slideHp != null) return;
        this.slideHp = transform.GetComponentInChildren<SlideHp>();
        Debug.LogWarning(transform.name + ": LoadSliderHp", gameObject);
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        this.HPShopwing();
    }
    protected virtual void HPShopwing()
    {
        if (this.ShootableObjectCtrl == null) return;
        bool isDead = this.shootableObjectCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            this.spawner.Despawn(transform);
            return;
        }

        float hp = this.shootableObjectCtrl.DamageReceiver.HP;
        float maxHp = this.shootableObjectCtrl.DamageReceiver.HPMax;

        this.slideHp.SetMaxHp(maxHp);
        this.slideHp.SetCurrentHP(hp);
    }
    public virtual void SetObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }
    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
}
