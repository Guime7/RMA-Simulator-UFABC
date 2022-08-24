using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperSensor : MonoBehaviour
{
    public bool colisao = false;

    void OnTriggerEnter(Collider other){
        this.colisao = true;
    }

    void OnTriggerExit(Collider other){
        this.colisao = false;
    }
}
