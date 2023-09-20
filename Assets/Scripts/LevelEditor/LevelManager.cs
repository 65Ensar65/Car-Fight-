using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : Base
{
    private int _levelIndex;

    [SerializeField] private bool IsFree;

    #region ForLevelSystem

    [SerializeField] private LevelScriptableObject[] levels;

    private LevelScriptableObject currentLevel;

    public LevelScriptableObject CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public int LevelIndex { get => PlayerPrefs.GetInt("Level"); set => PlayerPrefs.SetInt("Level", value); }

    private void OnEnable()
    {
        levels = Resources.LoadAll<LevelScriptableObject>("Levels");
        CurrentLevel = levels[LevelIndex % levels.Length];

        if (!IsFree)
            Instantiate(CurrentLevel.LevelPrefab);
    }

    public void OnPointerWin()
    {
        LevelIndex++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    #endregion

}