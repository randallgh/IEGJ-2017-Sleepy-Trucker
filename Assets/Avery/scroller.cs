using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour
{
    public float Speed;

    private void Start()
    {
        transform.Translate(new Vector3()
        {
            y = -400
        });
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3()
        {
            y = Time.deltaTime * Speed
        });
    }
}
