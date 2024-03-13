using System.Collections;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    protected float _destroyTimer = 10f;
    protected CharacterData _ownerData;
    protected CharacterBase _owner;
    
    private Coroutine _coDestroy;

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }

    protected void _StartDestroy(float delaySecond)
    {
        _StopDestroy();
        _coDestroy = StartCoroutine(_cDestroySkill(delaySecond));
    }

    protected void _StopDestroy()
    {
        if (_coDestroy == null) return;
        StopCoroutine(_coDestroy);
        _coDestroy = null;
    }
    
    private IEnumerator _cDestroySkill(float delaySecond)
    {
        yield return new WaitForSeconds(delaySecond);
        if (this.IsValid())
        {
            GameManager.Resource.Destroy(gameObject);
        }
    }
}
