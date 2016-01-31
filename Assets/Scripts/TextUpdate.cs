using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextUpdate : MonoBehaviour {

    public Text scoreCount;
    //private Text winText;

    private int count;

    public AudioClip hitSound;
    private AudioSource source;

    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            source.PlayOneShot(hitSound);
            count++;
            SetCountText();
        }
    }
    

    void SetCountText()
    {
        scoreCount.text = "Score P2: " + count.ToString();
    }
}
