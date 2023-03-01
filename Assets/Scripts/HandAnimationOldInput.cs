using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationOldInput : MonoBehaviour
{
    public Animator handAnim;

    public string gripButton;

    private void Start()
    {
        
    }

    public void Update()
    {
        //Grip Button
        if (Input.GetButton(gripButton))
        {
            handAnim.SetBool("gripped", true);
        }

        if (Input.GetButtonUp(gripButton))
        {
            handAnim.SetBool("gripped", false);
        }
    }
}
