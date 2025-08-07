using UnityEngine;

public class Dash_State : IState
{
    public void Enter(PlayerProperties _playerData)
    {
        // Dash animasyonu 
    }

    public void Exit(PlayerProperties _playerData)
    {
        // Hedef alınılabilirlik değiştirilmesi.
    }

    public void Update(PlayerProperties _playerData)
    {
        Dash();
        // Transform değişikliği ve diğer statelere geçiş
    }

    void Dash()
    {
        
    }
}
