using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BindingSkillController : SkillController
{
    protected override void _OnUpdate()
    {
        if (Utils.InputSkillKey)
        {
            DoSkillJob();
        }
    }
    
    protected override void DoSkillJob()
    {
        float radius = 3.0f;

        Collider[] bindedMonsters = Physics.OverlapSphere(_owner.Character.transform.position, radius, LayerMask.GetMask("Monster"));
        bool isDefensePowerReduced = bindedMonsters.Length < TempStoredInfo.BindingSkillDefenseReduceConditionCount; 
        foreach (var monster in bindedMonsters)
        {
            var mc = monster.GetComponent<MonsterController>();
            mc.OnMonsterBinded.Invoke(isDefensePowerReduced);
        }
    }
}
