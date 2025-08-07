using NUnit.Framework;
using UnityEngine;

public class JumpState : IState
{
    public void Enter(PlayerProperties player)
    {
        player._animator.SetTrigger("Jump");
        Jump(player);
    }

    public void Exit(PlayerProperties player)
    {
        Debug.Log("JumpState'den çikildi");
    }

    public void Update(PlayerProperties player)
    {
        if (player._isGrounded)
        {
            player._isJumping = false;
        }

        if (player._isGrounded && player._isWalking)     // Karakter yerde ve yürüyorsa...
        {
            player.ChangeState(player._walkState);          // Yürüme state'ine geç
        }
        else if (player._isGrounded)                     // Karakter yerde ise...
        {
            player.ChangeState(player._idleState);          // Idle state'ine geç
        }
    }

    void Jump(PlayerProperties player)
    {
        player._rb.linearVelocity = new Vector2(player._rb.linearVelocity.x, 0f);
        player._rb.AddForce(Vector2.up * player._jumpPower, ForceMode2D.Impulse);
    }
}
