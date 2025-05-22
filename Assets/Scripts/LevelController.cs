using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Level> levels;
    
    private Level currentLevel;
    
    public static LevelController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // public Transform GetSpawnPoint()
    // {
    //     return currentLevel.GetSpawnPoint();
    // }

    public RagdollController LoadFirstLevel()
    {
        var firstLevelId = levels.Count - 1;
        var level = Instantiate(levels[firstLevelId]);
        currentLevel = level;
        return currentLevel.GetRagdollController();
    }

    public RagdollController ReloadLevel()
    {
        var destroyedLevel = DestroyCurrentLevel();
        
        var level = Instantiate(levels[destroyedLevel]);
        currentLevel = level;
        return currentLevel.GetRagdollController();
    }

    public void LoadNextLevel()
    {
        var destroyedLevel = DestroyCurrentLevel();
        var nextLevelID = (destroyedLevel + 1) % levels.Count;
        
        var level = Instantiate(levels[nextLevelID]);
        currentLevel = level;
    }
    
    private int DestroyCurrentLevel()
    {
        var levelID = currentLevel.GetID();
        Destroy(currentLevel.gameObject);
        
        return levelID;
    }
}
