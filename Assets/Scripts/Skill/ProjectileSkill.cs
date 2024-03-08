using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSkill : SkillBase
{
    private Vector3 _moveDir;
    private float _speed = 10f;
    
    public virtual void Initialize(Vector3 dir, float speed, float destroyTimer, CharacterData owner)
    {
        // Set GameObject info
        GameObject bullet = gameObject;
        bullet.tag = "Skill";
        bullet.layer = 10;
        
        // Set Stat info
        _ownerData = owner;
        _speed = speed;
        _moveDir = dir;
        _destroyTimer = destroyTimer;
        
        // Edit
        _owner = owner.Character;
        
        _StartDestroy(_destroyTimer);
    }
    
    protected override void Update()
    {
        transform.position += _moveDir * (_speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        IDamageable target = other.GetComponentInChildren<IDamageable>();
        target?.OnDamage(_ownerData != null ? _ownerData.AttackPower : 1);
    }
}
