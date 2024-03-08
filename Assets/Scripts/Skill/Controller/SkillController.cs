using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillController : MonoBehaviour
{
    protected CharacterData _owner;

    protected virtual void Start()
    {
        
    }

    // Init stat
    public void Initialize(CharacterData data)
    {
        _owner = data;
        
        _InitializeSkill();
    }
    
    protected virtual void _InitializeSkill() { }
    
    protected abstract void DoSkillJob();

    public Action OnPlayerChanged;

}
