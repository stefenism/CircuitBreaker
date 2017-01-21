using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour {

	[HideInInspector]
	public bool enabled;

	public float mashValue;
	public string objectType;

	public PlayerController player;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if(enabled)
		{
			if(objectType == "mash")
			{
				startMash();
			}
		}
	}

	void startMash()
	{
		mashValue -= 0.05f;

		if(mashValue < 0)
		{
			mashValue = 0;
		}

		if(mashValue >= 1)
		{
			enabled = false;
			player.canControl = true;
			player.mashing = false;
		}
	}
}
