using UnityEngine;

public class Idle_State : IState
{
    public void Enter(PlayerProperties player)
    {
        Debug.Log("IdleState'e girildi ");
    }

    public void Exit(PlayerProperties player)
    {
        Debug.Log("IdleState'den çikildi");
    }

    public void Update(PlayerProperties player)
    {
        if (player._isWalking)    // Karakter yürüyorsa ve yerdeyse...
        {
            player.ChangeState(player._walkState);    // O zaman Walk_State'e geç.
        }
        else if (player._isJumping) // Karakter zıplıyor ise...
        {
            player.ChangeState(player._jumpState);   // O zaman zıplama durumuna geç.
        }
    }                           
}
