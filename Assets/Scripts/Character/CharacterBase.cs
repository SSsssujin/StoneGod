using System;
using UnityEngine;

// Has responsibility for manage stats
public abstract class CharacterBase : MonoBehaviour, IDamageable
{
    [SerializeField]
    private CharacterData _CharacterData;

    private int _maxHp;
    private int _curHp;

    protected void Start()
    {
        _CharacterData.Character = this;
        _maxHp = _curHp = _CharacterData.MaxHP;
    }

    public void OnDamage(float damage)
    {
        _curHp -= (int)damage;

        if (_curHp <= 0)
        {
            _curHp = 0;
            OnDead?.Invoke();
            _OnDead();
        }
        
        Debug.Log(_CharacterData.Name + " HP : " + _curHp + "/" + _maxHp);
    }

    protected virtual void _OnDead() { }

    public event Action OnDead;
}
