using System;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Scene/SceneInfo", fileName = "Scene")]
public class SceneInfoCollection : ScriptableObject
{
    public SceneInfo[] SceneInfoList;
}

[Serializable]
public class SceneInfo
{
    [SerializeField] 
    private int level;
    [SerializeField]
    private string _sceneName;
    
    public string SceneName => _sceneName;
}
