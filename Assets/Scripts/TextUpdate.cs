﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextUpdate : MonoBehaviour {

    public Text scoreCount;
    //private Text winText;

    private int count;

    // Use this for initialization
    void Start ()
    {
        count = 0;
        SetCountText();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Collision");
            count++;
            SetCountText();
        }
    }
    

    void SetCountText()
    {
        scoreCount.text = "Score P2: " + count.ToString();
    }
}
