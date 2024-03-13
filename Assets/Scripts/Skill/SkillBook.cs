using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillBook
{
    [SerializeField]
    private List<string> _skillNameList;
    
    private List<SkillController> _skillList = new();

    private CharacterData _owner;

    public void Initialize(CharacterData owner)
    {
        _owner = owner;

        _AddSkill();
    }

    public void _AddSkill()
    {
        foreach (var skillType in _skillNameList)
        {
            Type classType = Type.GetType(skillType);
            Component skillController = _owner.Model.GetComponent(classType);
            skillController ??= _owner.Model.AddComponent(classType);
            (skillController as SkillController)?.Initialize(_owner);
            _skillList.Add(skillController as SkillController);
        }
    }
}
