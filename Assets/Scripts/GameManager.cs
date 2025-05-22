using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RagdollController ragdollPrefab;
    
    public RagdollController CurrentRagdoll { get; private set; }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadFirstLevel();
    }

    public void OnRestartPressed()
    {
        if (CurrentRagdoll != null)
            Destroy(CurrentRagdoll.gameObject);

        RestartLevel();
    }

    private void LoadFirstLevel()
    {
        CurrentRagdoll = LevelController.Instance.LoadFirstLevel();
        TrySetRagdollAppearance();
    }

    private void RestartLevel()
    {
        CurrentRagdoll = LevelController.Instance.ReloadLevel();
        TrySetRagdollAppearance();
    }

    private void TrySetRagdollAppearance()
    {
        if (CustomizationController.Instance != null && CustomizationController.Instance.Appearance != null)
            CurrentRagdoll.RagdollAppearanceController.SetAppearance(CustomizationController.Instance.Appearance);
    }

    // private void SpawnRagdoll()
    // {
    //     CurrentRagdoll = Instantiate(ragdollPrefab);
    //     CurrentRagdoll.transform.position = LevelController.Instance.GetSpawnPoint().position;
    //     
    //     if (CustomizationController.Instance != null && CustomizationController.Instance.Appearance != null)
    //         CurrentRagdoll.RagdollAppearanceController.SetAppearance(CustomizationController.Instance.Appearance);
    // }
}
