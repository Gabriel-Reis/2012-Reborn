﻿using UnityEngine;

public class AnimatorScript : StateMachineBehaviour
{
    private Animation anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        //anim["spin"].layer = 123;
    }

    // double the spin speed when true
   // private bool fastSpin = false;

    void Update()
    {
        // leave spin or jump to complete before changing
        //if (anim.isPlaying)
        //{
        //    return;
        //}

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.Play("Walk");
        }

        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    anim.Play("jump");
        //}

        // combine jump and spin
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Jumping and spinning");
        //    anim.Play("jump");
        //    anim.Play("spin");
        //}

        // have spin speed reverted to 1.0 second
        //if (fastSpin == true)
        //{
        //    anim["spin"].speed = 1.0f;
        //    fastSpin = false;
        //}

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    Debug.Log("Jumping and spinning in half a second");
        //    anim.Play("jump");
        ///    anim["spin"].speed = 2.0f;
        //    anim.Play("spin");

            // we've used spin at a speed of two, now mark
            // the spin speed to revert back to one
        //    fastSpin = true;
        //}
    }
}
