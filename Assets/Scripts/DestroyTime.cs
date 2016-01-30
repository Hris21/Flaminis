using UnityEngine;
using System.Collections;

public class DestroyTime : MonoBehaviour {

    public float destroyTime = 1.5f;

    void Update ()
    {
        Destroy(gameObject, destroyTime);
	}
}
