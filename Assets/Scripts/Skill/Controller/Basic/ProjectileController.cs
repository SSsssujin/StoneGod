using UnityEngine;

public class ProjectileController : SkillController
{
    private const float _lifeTime = 10f;
    private const float _speed = 50f;
    
    private float _shootInterval = 0.25f;
    private float _lastShootTime;

    protected override void Start()
    {
        
    }

    protected override void _InitializeSkill()
    {
        _shootInterval = Utils.ConvertAttackSpeedToInterval(_owner.AttackSpeed);
    }

    protected override void _OnUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time >= _lastShootTime + _shootInterval)
        {
            DoSkillJob();
        }
    }

    protected override void DoSkillJob()
    {
        _GenerateProjectile();
        _lastShootTime = Time.time;
    }

    private void _GenerateProjectile()
    {
        // Generate projectile
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.localScale = Vector3.one * 0.25f;
        bullet.transform.position = GameManager.Player.transform.position;
        ProjectileSkill ps = bullet.DemandComponent<ProjectileSkill>();
        bullet.GetComponent<Collider>().isTrigger = true;
        bullet.DemandComponent<Rigidbody>().useGravity = false;
        ps.Initialize(GameManager.Player.transform.forward, _speed, _lifeTime, _owner, "Player");
    }
}
