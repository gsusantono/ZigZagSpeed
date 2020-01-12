using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private ScoreManager scoreManager;
 

    void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.tag=="Player")
        {
           
            Invoke("FallDown", 0.8f);
           
        }
    }

    //Drop Platform
    private void FallDown()
    {


        this.GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(this.transform.parent.gameObject, 2f);
    }
}
