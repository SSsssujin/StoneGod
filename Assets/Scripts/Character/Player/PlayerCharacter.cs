using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : CharacterBase
{
    private PlayerCharacterData _playerCharacterData;
    
    // Common stats
    public int SkillPoint = 5;
    
    // Individual stats
    public int Hp;
    public float AttackPower;
    public float AttackSpeed;
    public float DefensePower;

    public void Initialize()
    {
        _CharacterData.Start();
        //_CharacterData.Activate();
    }

    public void ChangePlayer()
    {
        // Push tester
    }
}
