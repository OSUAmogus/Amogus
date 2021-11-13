using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    float MoveSide;
    float MoveUp;
    float MoveDown;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        MoveSide = Input.GetAxisRaw("Horizontal");
        MoveUp = Input.GetAxisRaw("Vertical");
        MoveDown = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Hmov", Mathf.Abs(MoveSide));
        animator.SetFloat("Umov", Mathf.Abs(MoveUp));
        animator.SetFloat("Dmov", Mathf.Abs(MoveDown));
    }
}
