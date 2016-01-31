using UnityEngine;


public class CutsceneTransition : MonoBehaviour
{
    public float countdown = 29.50f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
