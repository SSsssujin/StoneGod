using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleSkillController : SkillController
{
    protected int _requiredSkillPoint = 1;
    
    protected override void _OnUpdate()
    {
        if (Utils.InputSkillKey)
        {
            DoSkillJob();
        }
    }
}
