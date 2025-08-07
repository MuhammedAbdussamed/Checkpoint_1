using NUnit.Framework;
using UnityEngine;

public class JumpState : IState
{
    public void Enter(PlayerProperties _playerData)
    {
        _playerData._animator.SetTrigger("Jump");
        Jump(_playerData);
    }

    public void Exit(PlayerProperties _playerData)
    {
        Debug.Log("JumpState'den çikildi");
    }

    public void Update(PlayerProperties _playerData)
    {
        _playerData._playerController.Run(_playerData);            // Yürüme fonksiyonlarını burada da çalıştırmalıyız ki havada karaktere yön verebilelim.

        if (_playerData._isGrounded)                               // Karakter yerde true dönerse...
        {
            _playerData._isJumping = false;                             // Karakter zıplıyoru false çevir
        }

        if (_playerData._isGrounded && _playerData._isWalking)     // Karakter yerde ve yürüyorsa...
        {
            _playerData.ChangeState(_playerData._walkState);            // Yürüme state'ine geç
        }
        else if (_playerData._isGrounded)                          // Karakter yerde ise...
        {
            _playerData.ChangeState(_playerData._idleState);            // Idle state'ine geç
        }
    }

    void Jump(PlayerProperties _playerData)
    {
        _playerData._rb.linearVelocity = new Vector2(_playerData._rb.linearVelocity.x, 0f);
        _playerData._rb.AddForce(Vector2.up * _playerData._jumpPower, ForceMode2D.Impulse);
    }
}
