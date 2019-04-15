﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "CubeTag" || other.gameObject.tag == "GroundTag") {
			this.GetComponent<AudioSource> ().Play();
		}
	}
}
