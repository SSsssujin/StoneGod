using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnpanmanProjectile : ProjectileSkill
{
    public override void Initialize(Vector3 dir, float speed, float destroyTimer, CharacterData owner)
    {
        base.Initialize(dir, speed, destroyTimer, owner);
        
        _owner?.OnDamage(TempStoredInfo.AnpanmanProjectileExpense);
    }
}
