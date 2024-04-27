using StarterAssets;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Transform _playerBody;

    [SerializeField]
    private StarterAssetsInputs _starterAssetsInputs;

    public Camera Camera => _camera;
    public Transform PlayerBody => _playerBody;

    public bool PlayerJumpInput => _starterAssetsInputs.jump;

    public Vector2 MoveInput => _starterAssetsInputs.move;

    public static PlayerData Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
    }
}