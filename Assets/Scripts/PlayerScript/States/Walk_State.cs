using UnityEngine;

public class Walk_State : IState
{
    public void Enter(PlayerProperties _playerData)
    {
        Debug.Log("WalkState'e girildi ");
    }

    public void Exit(PlayerProperties _playerData)
    {
        Debug.Log("WalkState'den çikildi");
    }

    public void Update(PlayerProperties _playerData)
    {
        _playerData._playerController.Run(_playerData);     // playerProperties üzerinden playerController'a eriştik ve orada ki run fonksiyonunu çalıştırdık.

        if (!_playerData._isWalking)        // Karakter yürümüyorsa ve yerdeyse...
        {
            _playerData.ChangeState(_playerData._idleState);   // O zaman Idle durumuna geç.
        }
        else if (_playerData._isJumping)    // Karakter zıplıyor ise...
        {
            _playerData.ChangeState(_playerData._jumpState);   // O zaman zıplama durumuna geç.
        }
        else if (_playerData._isDashing)    // Karakter atılıyorsa
        {
            _playerData.ChangeState(_playerData._dashState);   // O zaman atılma durumuna geç. 
        }
    }

}
