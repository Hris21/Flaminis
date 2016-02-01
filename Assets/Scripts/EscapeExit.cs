using UnityEngine;
using System.Collections;

public class EscapeExit : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.Return))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }
}
