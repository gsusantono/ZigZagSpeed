using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    Transform Target;
    Vector3 offset;
	void Start () {
        offset = Target.transform.position - this.transform.position;
	}
	

	void Update () {
        if (Target.gameObject.GetComponent<Player>().CanMove)
        {
            Vector3 ReqPos = Target.transform.position - offset;
            this.transform.position = Vector3.Lerp(this.transform.position, ReqPos, 1.5f);
        }
	}
}
