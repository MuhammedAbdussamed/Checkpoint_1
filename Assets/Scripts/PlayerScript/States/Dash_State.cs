using UnityEngine;
using System.Collections;

public class Dash_State : IState
{
    public void Enter(PlayerProperties _playerData)
    {
        Dash(_playerData);                                              // Atılma fonksiyonu.
        _playerData._mono.StartCoroutine(ResetDash(_playerData));       // Dashi sıfırla.

        _playerData._animator.SetTrigger("Dash");
        _playerData._playerLayer = LayerMask.NameToLayer("Invisible");  // Karakterin katmanını değiştir.
    }

    public void Exit(PlayerProperties _playerData)
    {
        _playerData._playerLayer = LayerMask.NameToLayer("Characters"); // Karakterin katmanını değiştir.
    }

    public void Update(PlayerProperties _playerData)
    {
        if (!_playerData._isDashing && _playerData._isWalking)          // Dash bitti ve karakter yürüyorsa...
        {
            _playerData.ChangeState(_playerData._walkState);                    // O zaman WalkState'e geç
        }
        else if (!_playerData._isDashing && !_playerData._isWalking)    // Dash bitti ve karakter yürümüyorsa...
        {
            _playerData.ChangeState(_playerData._idleState);                    // O zaman IdleState'e geç
        }
        else if (!_playerData._isDashing && _playerData._isJumping)     // Dash bitti ve karakter zıplıyorsa
        {
            _playerData.ChangeState(_playerData._jumpState);                    // O zaman JumpState'e geç
        }
    }

    void Dash(PlayerProperties _playerData)
    {
        Vector2 dashDirection = _playerData._isFacingRight ? Vector2.right : Vector2.left;  // Karakter sağa bakıyorsa sağa , sola bakıyorsa sola yön belirle ve değişkene ata.
        _playerData._rb.linearVelocity = dashDirection * _playerData._dashSpeed;            // Belirlenen yöne doğru dashSpeed büyüklüğünde bir kuvvet uygula.
    }

    IEnumerator ResetDash(PlayerProperties _playerData)
    {
        yield return new WaitForSeconds(_playerData._dashTime);                             // dashTime kadar bekle.
        _playerData._rb.linearVelocity = Vector2.zero;                                      // Hızı sıfırla.
        _playerData._isDashing = false;                                                     // State'den çıkmak için isDashing'i false döndür.
    }
}
