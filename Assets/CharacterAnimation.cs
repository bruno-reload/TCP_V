using Character.Control;
using System;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private CharacterControl characterControl;
    private new Rigidbody rigidbody;
    private TeamSelection team;

    private Animator anim;

    private void Awake()
    {
        this.anim = GetComponentInChildren<Animator>();
        this.rigidbody = GetComponent<Rigidbody>();
        this.team = GetComponent<TeamSelection>();
        this.anim.Play("Idle");
    }
    public void Floor(bool value)
    {
        Debug.Log("onFloor");
        this.anim.SetBool("onFloor", value);
    }

    public void Jumping()
    {
        this.anim.SetFloat("vertical", float.Parse(this.rigidbody.velocity.normalized.y.ToString("0.00")));
    }

    public void Dive()
    {
        this.anim.SetTrigger("dive");
    }

    public void Idle()
    {
        this.anim.SetFloat("vertical", 0.00f);
        this.anim.SetFloat("horizontalX", 0.00f);
        this.anim.SetFloat("horizontalZ", 0.00f);
    }

    public void Move()
    {
        this.anim.SetFloat("horizontalZ", float.Parse(this.rigidbody.velocity.normalized.z.ToString("0.00")) * this.team.Convert());
    }

    internal void Victory()
    {
        Debug.Log("victory");
        Debug.LogWarning("implementar uma animação de vitória");
    }
}
