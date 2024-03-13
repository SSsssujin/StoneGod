using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSkill : SkillBase
{
    private Vector3 _moveDir;
    private float _speed = 10f;
    private string _avoidTag;
    
    public virtual void Initialize(Vector3 dir, float speed, float destroyTimer, CharacterData owner, string avoidTag)
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
        _avoidTag = avoidTag;
        
        // Edit
        _owner = owner.CharacterBase;
        
        _StartDestroy(_destroyTimer);
    }
    
    protected override void Update()
    {
        transform.position += _moveDir * (_speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_avoidTag))
            return;
        
        IDamageable target = other.GetComponentInChildren<IDamageable>();
        target?.OnDamage(_ownerData != null ? _ownerData.AttackPower : 1);
    }
}
