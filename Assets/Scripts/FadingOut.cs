﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingOut : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;
	private int fadeDir = 1; // fadein = 1, fadeout = -1

	// order in draw hierarchy, will be rendered on top of everything
	private int drawDepth = -1000; 

	private float alpha = 0.0f;

	void OnGUI() {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	public float BeginFade(int direction) {
		fadeDir = direction;
		return (fadeSpeed);
	}

	void OnLevelWasLoaded() {
		BeginFade(1);
	}

}

