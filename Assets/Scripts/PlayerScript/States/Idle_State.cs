using UnityEngine;

public class Idle_State : IState
{
    public void Enter(PlayerProperties _playerData)
    {
        /* Idle durumuna girince yapılacaklar buraya */
    }

    public void Exit(PlayerProperties _playerData)
    {
        /* Idle durumundan çıkınca yapılacaklar buraya */
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
