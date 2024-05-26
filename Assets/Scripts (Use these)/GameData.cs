using UnityEngine;

public class GameData : MonoBehaviour
{
    [HelpBox("This script gives you access to some information about the player and the game\n" +
             "Take a look at this script's code to see available properties!")]
    public bool helpBox;

    public Camera FirstPersonCamera => PlayerData.Instance.Camera;

    public Vector3 FirstPersonCameraLookDirection => PlayerData.Instance.Camera.transform.forward;

    public Vector3 PlayerPosition => PlayerData.Instance.PlayerBody.position;

    public Vector2 PlayerMoveInput => PlayerData.Instance.MoveInput;

    public bool PlayerJumpInput => PlayerData.Instance.PlayerJumpInput;
}