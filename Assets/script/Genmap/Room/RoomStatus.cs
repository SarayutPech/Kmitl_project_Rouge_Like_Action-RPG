using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStatus : MonoBehaviour
{
    public bool isclear = false;
    [SerializeField] private Vector3 roomPosition;

    private void Awake()
    {
        roomPosition = transform.position;
    }

    public bool setClear( bool status )
    {
        return status;
    }

    public bool getClear()
    {
        return isclear;
    }
}
