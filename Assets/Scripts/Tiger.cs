using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger : MonoBehaviour {
    Animator anim;
    [SerializeField] GameObject movementData;
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	void Update () {
        anim.SetBool("Run", movementData.GetComponent<MovementData>().isShaking);
	}
}
