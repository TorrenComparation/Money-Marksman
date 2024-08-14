using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    public void ChangeConfiguration(bool canMove)
    {
        _playerMovement.canMove = canMove;
        _playerMovement.GetState();
    }
}
