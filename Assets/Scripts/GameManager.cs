using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public float levelBlockSpeed = 1;
    public float playerBlockSpeed = 1;

    public static GameManager instance { get; private set; }
    [SerializeField]
    private GridManager _gridManager;
    public GridManager gridManager => _gridManager;
    
    [SerializeField] 
    private PlayerPieceSpawner _playerPieceSpawner;
    public PlayerPieceSpawner playerPieceSpawner => _playerPieceSpawner;
    
    [SerializeField] 
    private Player _player;
    public Player player => _player;
    

    public int gameLevel { get; private set; } = 1;
    public bool gameStarted { get; private set; } = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); 
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        Init();
    }

    private void Init()
    {
        gridManager.Init();
        playerPieceSpawner.Init();
        player.Init();
        gameStarted = true;
    }
}
