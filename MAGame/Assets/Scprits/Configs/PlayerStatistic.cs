using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatistic", menuName = "Configs/PlayerStatistic")]
public class PlayerStatistic : ScriptableObject
{
    public float walkSpeed;
    public float runSpeed;
    public float crouchSpeed;
    public float jumpForce;
    public float gravity;
    public float lookSpeed;
    public float lookXLimit;
    public float defaultHeight;
    public float crouchHeigth;
}
