using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class CharacterData : ScriptableObject
{
    public int TemplateID;
    public string Name;
    public GameObject Model;
    
    public int MaxHP;
    [Range(1, 5)] public float AttackPower;
    [Range(1, 5)] public int AttackSpeed;
    public float DefensePower;

    public SkillBook SkillBook;

    // Edit
    public CharacterBase Character;

    public virtual void Start()
    {
        
    }
    
    public virtual void Exit()
    {
        
    }
}
