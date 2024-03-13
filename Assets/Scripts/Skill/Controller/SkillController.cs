using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillController : MonoBehaviour
{
    protected CharacterData _owner;
    protected float _cooldownTime;

    protected virtual void Start()
    {
        
    }

    // Init stat
    public void Initialize(CharacterData data)
    {
        _owner = data;
        
        _InitializeSkill();
    }

    // Edit later
    private void Update()
    {
        _OnUpdate();
    }

    protected virtual void _InitializeSkill() { }
    
    protected abstract void DoSkillJob();

    protected virtual void _OnUpdate() { }

    public Action OnPlayerChanged;

}
