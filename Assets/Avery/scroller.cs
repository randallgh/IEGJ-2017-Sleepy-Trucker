using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour
{
    static bool seenCredits = false;
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

        if (seenCredits)
        {
            Application.LoadLevel(0);
        }

        if (Time.timeSinceLevelLoad > 10)
        {
            seenCredits = true;
            Application.LoadLevel(0);
        }
    }
}
