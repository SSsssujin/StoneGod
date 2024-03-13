using UnityEngine;

public class BindingSkillController : BattleSkillController
{
    protected override void DoSkillJob()
    {
        float radius = 3.0f;
        Collider[] bindedMonsters = Physics.OverlapSphere(_owner.CharacterBase.transform.position, radius, LayerMask.GetMask("Monster"));
        bool isDefensePowerReduced = bindedMonsters.Length < TempStoredInfo.BindingSkillDefenseReduceConditionCount; 
        foreach (var monster in bindedMonsters)
        {
            var mc = monster.GetComponent<MonsterController>();
            mc?.MonsterBinded.Invoke(isDefensePowerReduced);
        }
        
        Debug.Log("Bind [" + bindedMonsters.Length + "] monsters");
    }
}
