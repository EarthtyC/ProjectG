using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Game Settings")]
    public bool isMultiplayer = false;
    public int maxPlayers = 4;
    
    [Header("Debug")]
    public bool debugMode = true;
    
    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            if (debugMode)
                Debug.Log("GameManager initialized");
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        // Auto-load main menu after 2 seconds
        Invoke(nameof(LoadMainMenu), 2f);
    }
    
    private void LoadMainMenu()
    {
        if (debugMode)
            Debug.Log("Loading Main Menu...");
            
        // For now, just change the loading text
        var loadingText = FindObjectOfType<TMPro.TextMeshProUGUI>();
        if (loadingText != null)
        {
            loadingText.text = "Ready to Battle!";
        }
    }
}