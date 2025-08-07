using UnityEngine;

public class Walk_State : IState
{
    public void Enter(PlayerProperties player)
    {
        Debug.Log("WalkState'e girildi ");
    }

    public void Exit(PlayerProperties player)
    {
        Debug.Log("WalkState'den çikildi");
    }

    public void Update(PlayerProperties player)
    {
        Run(player);
        if (!player._isWalking)   // Karakter yürümüyorsa ve yerdeyse...
        {
            player.ChangeState(player._idleState);   // O zaman Idle durumuna geç.
        }
        else if (player._isJumping) // Karakter zıplıyor ise...
        {
            player.ChangeState(player._jumpState);   // O zaman zıplama durumuna geç.
        }
    }

    #region Functions
    private void Run(PlayerProperties playerData)
    {
        Vector2 newVelocity = new Vector2(playerData._playerMoveDirection.x * playerData._speed, playerData._rb.linearVelocity.y);
        playerData._rb.linearVelocity = newVelocity;       

        if (playerData._playerMoveDirection.x != 0f)
        {
            playerData._animator.SetBool("isWalking", true);
            playerData._isWalking = true;
        }

        else
        {
            playerData._animator.SetBool("isWalking", false);
            playerData._isWalking = false;
        }
    } 
    #endregion
       
}
