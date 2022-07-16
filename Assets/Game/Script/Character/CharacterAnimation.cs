using Character.Control;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Team;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private TeamSelection team;
    private Vector3 speed;
    private Animator anim;
    public bool dive = false;
    private float count;
    public bool Floor { get => this.anim.GetBool("onFloor"); private set { } }

    public float SpeedZ { get { return this.speed.z; } private set { } }

    private void Awake()
    {
        this.anim = GetComponentInChildren<Animator>();
        this.rigidbody = GetComponent<Rigidbody>();
        this.team = GetComponent<TeamSelection>();
        this.anim.Play("idle");
        //Debug.LogWarning("esse debug marca onde eu dexei a escala do tempo em .2");
        //Time.timeScale = .2f;
    }

    public void Jumping()
    {
        this.anim.SetBool("move", false);
    }

    public void Dive()
    {
        this.anim.SetTrigger("dive");
        count = anim.GetCurrentAnimatorStateInfo(0).length / anim.GetCurrentAnimatorStateInfo(0).speed;
        this.dive = true;
    }
    public bool IsDive()
    {
        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("dive") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) {
        //    this.dive = false;
        //}
        //if (!anim.GetCurrentAnimatorStateInfo(0).IsName("dive")) {
        //    this.dive = false;
        //}
        if (count < 0)
            this.dive = false;
        return this.dive;
    }
    public void Head()
    {
        if (this.dive)
            this.anim.SetTrigger("headDive");
        else
            this.anim.SetTrigger("head");
    }

    public void Idle()
    {
        this.anim.SetBool("move", false);
    }

    public void Move()
    {
        this.anim.SetBool("move", true);
    }

    private void Update()
    {
        this.speed.y = float.Parse(this.rigidbody.velocity.normalized.y.ToString("0.00"));
        this.anim.SetFloat("vertical", this.speed.y);
        count -= Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("FieldRange") && !this.anim.GetBool("onFloor"))
        {
            this.anim.SetBool("onFloor", true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("FieldRange") && this.anim.GetBool("onFloor"))
        {

            this.anim.SetBool("onFloor", false);
        }
    }
}
