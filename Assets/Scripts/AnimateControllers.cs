using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateControllers : MonoBehaviour
{
    Animator questAnim;
    public string button1;
    public string button2;
    public string button3;
    public string gripButton;
    public string triggerButton;
    public string yAxis;
    public string xAxis;
    private float yMovement;
    private float xMovement;

    // Start is called before the first frame update
    void Start()
    {
        questAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        yMovement = Input.GetAxis(yAxis);
        xMovement = Input.GetAxis(xAxis);

        //Joystick Controls

        questAnim.SetFloat("Joy X", xMovement);
        //Debug.Log("X Movement :" + xMovement);
        questAnim.SetFloat("Joy Y", -yMovement);
        //Debug.Log("Y Movement :" + yMovement);

        //Button 1
        if (Input.GetButton(button1))
        {
            questAnim.SetFloat("Button 1", 1);
        }

        if (Input.GetButtonUp(button1))
        {
            questAnim.SetFloat("Button 1", 0);
        }

        //Button 2
        if (Input.GetButton(button2))
        {
            questAnim.SetFloat("Button 2", 1);
        }

        if (Input.GetButtonUp(button2))
        {
            questAnim.SetFloat("Button 2", 0);
        }

        //Button 3
        if (Input.GetButton(button3))
        {
            questAnim.SetFloat("Button 3", 1);
        }

        if (Input.GetButtonUp(button3))
        {
            questAnim.SetFloat("Button 3", 0);
        }

        //Grip Button
        if (Input.GetButton(gripButton))
        {
            questAnim.SetFloat("Grip", 1);
        }

        if (Input.GetButtonUp(gripButton))
        {
            questAnim.SetFloat("Grip", 0);
        }


        //Trigger Button
        if (Input.GetButton(triggerButton))
        {
            questAnim.SetFloat("Trigger", 1);
        }

        if (Input.GetButtonUp(triggerButton))
        {
            questAnim.SetFloat("Trigger", 0);
        }

        
    }
}