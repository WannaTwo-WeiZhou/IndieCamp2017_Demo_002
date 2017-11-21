using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class RoleControl : MonoBehaviour
{
    public XboxController m_Ctrler;
    public float m_MinStickDragDis = 0.2f;

    private Role m_Role;

    void Awake()
    {
        m_Role = GetComponent<Role>();
    }

    void Start()
    {
        switch (m_Ctrler)
        {
            case XboxController.First:
                {
                    GetComponentInChildren<SpriteRenderer>().color =
                        Color.red;
                }
                break;
            case XboxController.Second:
                {
                    GetComponentInChildren<SpriteRenderer>().color =
                        Color.green;
                }
                break;
            case XboxController.Third:
                {
                    GetComponentInChildren<SpriteRenderer>().color =
                        Color.blue;
                }
                break;
            case XboxController.Fourth:
                {
                    GetComponentInChildren<SpriteRenderer>().color =
                        Color.yellow;
                }
                break;
        }
    }

    public void UpdateCtrl()
    {
        Vector2 vec = new Vector2();

        // Left Stick
        if (XCI.GetButtonDown(XboxButton.LeftStick, m_Ctrler))
        {

        }

        // Right Stick
        if (XCI.GetButtonDown(XboxButton.RightStick, m_Ctrler))
        {

        }

        // Left stick movement
        float axisLX = XCI.GetAxis(XboxAxis.LeftStickX, m_Ctrler);
        float axisLY = XCI.GetAxis(XboxAxis.LeftStickY, m_Ctrler);
        vec.x = axisLX;
        vec.y = axisLY;
        if (vec.magnitude > m_MinStickDragDis)
        {
            m_Role.Move(vec);
        }
            
        // Right stick movement
        float axisRX = XCI.GetAxis(XboxAxis.RightStickX, m_Ctrler);
        float axisRY = XCI.GetAxis(XboxAxis.RightStickY, m_Ctrler);
        vec.x = axisRX;
        vec.y = axisRY;
        if (vec.magnitude > m_MinStickDragDis)
        {
            m_Role.Turn(vec);
            m_Role.Shoot();
        }


        // D-Pad
        if (XCI.GetDPad(XboxDPad.Up, m_Ctrler))
        {
            m_Role.Move(Vector2.up);
        }
        if (XCI.GetDPad(XboxDPad.Down, m_Ctrler))
        {
            m_Role.Move(Vector2.down);
        }
        if (XCI.GetDPad(XboxDPad.Left, m_Ctrler))
        {
            m_Role.Move(Vector2.left);
        }
        if (XCI.GetDPad(XboxDPad.Right, m_Ctrler))
        {
            m_Role.Move(Vector2.right);
        }


        // A,B,X,Y
        if (XCI.GetButton(XboxButton.A, m_Ctrler))
        {
            m_Role.Turn(Vector2.down);
            m_Role.Shoot();
        }
        if (XCI.GetButton(XboxButton.B, m_Ctrler))
        {
            m_Role.Turn(Vector2.right);
            m_Role.Shoot();
        }
        if (XCI.GetButton(XboxButton.X, m_Ctrler))
        {
            m_Role.Turn(Vector2.left);
            m_Role.Shoot();
        }
        if (XCI.GetButton(XboxButton.Y, m_Ctrler))
        {
            m_Role.Turn(Vector2.up);
            m_Role.Shoot();
        }

        // Trigger input
        float trigL = XCI.GetAxis(XboxAxis.LeftTrigger, m_Ctrler);
        float trigR = XCI.GetAxis(XboxAxis.RightTrigger, m_Ctrler);

        // Bumper input
        if (XCI.GetButtonDown(XboxButton.LeftBumper, m_Ctrler))
        {

        }
        if (XCI.GetButtonDown(XboxButton.RightBumper, m_Ctrler))
        {

        }

        // Start and back, same as bumpers but smaller bullets
        if (XCI.GetButtonUp(XboxButton.Back, m_Ctrler))
        {

        }
        if (XCI.GetButtonUp(XboxButton.Start, m_Ctrler))
        {

        }
    }
}
