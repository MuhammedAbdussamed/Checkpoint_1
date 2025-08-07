using UnityEngine;

public interface IState
{
    void Enter(PlayerProperties player);
    void Update(PlayerProperties player);
    void Exit(PlayerProperties player);
}