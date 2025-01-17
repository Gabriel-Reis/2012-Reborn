﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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

        if(Input.GetKey(KeyCode.P)){
            SceneManager.LoadScene("Level2");
        }

    }
}