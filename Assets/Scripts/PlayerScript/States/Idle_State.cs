using UnityEngine;

public class Idle_State : IState
{
    public void Enter(PlayerProperties _playerData)
    {
        Debug.Log("IdleState'e girildi ");
    }

    public void Exit(PlayerProperties _playerData)
    {
        Debug.Log("IdleState'den çikildi");
    }

    public void Update(PlayerProperties _playerData)
    {
        if (_playerData._isWalking)      // Karakter yürüyorsa ve yerdeyse...
        {
            _playerData.ChangeState(_playerData._walkState);    // O zaman yürüme durumuna geç.
        }
        else if (_playerData._isJumping) // Karakter zıplıyor ise...
        {
            _playerData.ChangeState(_playerData._jumpState);   // O zaman zıplama durumuna geç.
        }
        else if (_playerData._isDashing) // Karakter atılıyor ise
        {
            _playerData.ChangeState(_playerData._dashState);    // O zaman atılma durumuna geç
        }
    }                           
}
