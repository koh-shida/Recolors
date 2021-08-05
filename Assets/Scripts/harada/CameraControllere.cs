using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ƒJƒƒ‰‚ğ‘€‚éƒNƒ‰ƒX
/// </summary>
public class CameraControllere : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 0) {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }


    }
}
