using UnityEngine;

public class Shaft : Interactable_Object
{
    protected override void ObjectFunction()
    {
        _animator.SetTrigger("Shaft");
    }
}
