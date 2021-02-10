using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform Player;

    private void LateUpdate()
    {
        Vector3 new_position = Player.position;
        new_position.y = transform.position.y;
        transform.position = new_position;
    }

}
