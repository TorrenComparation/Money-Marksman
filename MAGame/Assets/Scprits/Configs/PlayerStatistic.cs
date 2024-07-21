using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatistic", menuName = "Configs/PlayerStatistic")]
public class PlayerStatistic : ScriptableObject
{

    [SerializeField] private float _crouchSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;
    [SerializeField] private float _lookSpeed;
    [SerializeField] private float _lookXLimit;
    [SerializeField] private float _defaultHeight;
    [SerializeField] private float _crouchHeigth;
    public float walkSpeed;
    public float runSpeed;


    public float crouchSpeed => _crouchSpeed;
    public float jumpForce => _jumpForce;
    public float gravity => _gravity;
    public float lookSpeed => _lookSpeed;
    public float lookXLimit => _lookXLimit;
    public float defaultHeight => _defaultHeight;
    public float crouchHeigth => _crouchHeigth;
}
