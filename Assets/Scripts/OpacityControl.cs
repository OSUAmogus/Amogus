using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float percent;
    public SpriteRenderer render;
    void Start()
    {
        //render = gameObject.GetComponent<SpriteRenderer>();
        render.color = new Color(1f, 1f, 1f, percent);
    }
}
