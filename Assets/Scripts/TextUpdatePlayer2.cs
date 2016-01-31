using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextUpdatePlayer2 : MonoBehaviour {

    public Text scoreCount;
    //private Text winText;

    private int count;

    public AudioClip hitSound;
    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet1"))
        {
            source.PlayOneShot(hitSound);
            count++;
            SetCountText();
        }

        if (count >= 50)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndGameRed");
        }
    }


    void SetCountText()
    {
        scoreCount.text = "Score P1: " + count.ToString();
    }
}
