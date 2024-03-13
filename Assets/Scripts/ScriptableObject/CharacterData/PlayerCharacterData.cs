using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterData/Player", fileName = "Player", order = 0)]
public class PlayerCharacterData : CharacterData
{
    private bool _isActivated;
    
    public override void Start()
    {
        // Create my model
        string key = "TestPlayerModels/" + Name + ".prefab";
        Model = GameManager.Resource.Instantiate(key, GameManager.Player.transform);
        Model.transform.ResetLocal();
        
        // Set Skills
        SkillBook.Initialize(this);
        
        //Model.gameObject.SetActive(false);
    }

    public void Activate()
    {
        _isActivated = true;
        Model.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActivated = false;
        Model.gameObject.SetActive(false);
    }

    public override void Exit()
    {
        //GameManager.Resource.Destroy(Model);   
    }
}
