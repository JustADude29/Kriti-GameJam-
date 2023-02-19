using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;

    Vector3 offSet;
    private void Start() {
        offSet=transform.position-Player.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position=Player.transform.position+offSet;
    }
}
