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
        animator.SetFloat("Hmov", Mathf.Abs(MoveSide));

        MoveUp = Input.GetAxisRaw("Vertical");
    }
}
