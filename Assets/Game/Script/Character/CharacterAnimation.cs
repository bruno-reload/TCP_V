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
    private float speedZ;
    private Animator anim;
    public bool Floor { get => this.anim.GetBool("onFloor"); private set { } }

    public float SpeedZ { get { return this.speedZ; } private set { } }

    private void Awake()
    {
        this.anim = GetComponentInChildren<Animator>();
        this.rigidbody = GetComponent<Rigidbody>();
        this.team = GetComponent<TeamSelection>();
        this.anim.Play("Idle");
    }

    public void Jumping()
    {
        this.anim.SetFloat("vertical", this.speedZ);
        this.anim.SetBool("dive", false);
    }

    public void Dive()
    {
        this.anim.SetBool("dive", true);
    }
    public bool EndDive()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(2).IsName("dive") && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
        {
            this.anim.SetBool("dive", false);
        }
        return !this.anim.GetBool("dive");
    }
    public void Head()
    {
        this.anim.SetTrigger("head");
    }

    public void Idle()
    {
        this.anim.SetFloat("vertical", 0.00f);
        this.anim.SetFloat("horizontalX", 0.00f);
        this.anim.SetFloat("horizontalZ", 0.00f);
        this.anim.SetBool("dive", false);
    }

    public void Move()
    {
        this.anim.SetFloat("horizontalZ", this.speedZ * this.team.Convert());
        this.anim.SetBool("dive", false);
    }

    internal void Victory()
    {
        Debug.Log("victory");
        Debug.LogWarning("implementar uma animação de vitória");
    }
    private void Update()
    {
        this.speedZ = float.Parse(this.rigidbody.velocity.normalized.z.ToString("0.00"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Field") && !this.anim.GetBool("onFloor"))
        {
            this.anim.SetBool("onFloor", true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Field") && this.anim.GetBool("onFloor"))
        {

            this.anim.SetBool("onFloor", false);
        }
    }
}
