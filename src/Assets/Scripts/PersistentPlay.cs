﻿using UnityEngine;
using System.Collections;

public class PersistentPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
