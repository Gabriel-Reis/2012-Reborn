using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movimentation : MonoBehaviour {
    Animator anim;

    void Start () {
        anim = GetComponent<Animator> ();
    }

    void Update () {
        
        var estaMovendo = Input.GetAxis("Vertical");
        if (estaMovendo != 0) {
            anim.SetBool("estaAndando", true);
        } else {
            anim.SetBool("estaAndando", false);
        }
    }
}