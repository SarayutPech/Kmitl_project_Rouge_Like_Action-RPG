using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStatus : MonoBehaviour
{
    [SerializeField] private bool isclear = false;
    
    public bool setClear( bool status )
    {
        return status;
    }

    public bool getClear()
    {
        return isclear;
    }
}
