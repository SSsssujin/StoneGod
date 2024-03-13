using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnpanmanProjectileController : ProjectileController
{
    private const int handicap = 1;
    
    protected override void DoSkillJob()
    {
        base.DoSkillJob();
        _owner.Character.OnDamage(handicap);
    }

}
