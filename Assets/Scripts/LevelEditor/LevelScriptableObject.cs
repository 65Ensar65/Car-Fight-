using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelEditor", menuName = "LevelEditor")]
public class LevelScriptableObject : ScriptableObject
{
    [SerializeField] public GameObject LevelPrefab;
}
