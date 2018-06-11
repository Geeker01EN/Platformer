using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    [SerializeField] float time;
    [SerializeField] GameObject me;

	void Update () {
        if (time < 0)
        {
            Destroy(me);
        }
        time -= Time.deltaTime;
	}
}
