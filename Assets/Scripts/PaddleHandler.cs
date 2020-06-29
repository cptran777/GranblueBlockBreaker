using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleHandler : MonoBehaviour {
    void Start() {
        print("We're starting?");
    }

    void Update() {
        Debug.Log(Input.mousePosition);
    }
}
