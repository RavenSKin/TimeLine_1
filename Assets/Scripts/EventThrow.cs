using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventThrow : MonoBehaviour
{
    public Throw _throw;
    
   public void ThrowElement()
    {
        _throw.Throw_It();
    }
}
