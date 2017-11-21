using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class InputManager : MonoBehaviour
{
	public List<RoleControl> m_AllCtrls = new List<RoleControl>();

    void Start()
    {

        // This code only works on Windows
        if (Application.platform == RuntimePlatform.WindowsPlayer || 
			Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("Windows Only:: Any Controller Plugged in: " + 
				XCI.IsPluggedIn(XboxController.Any).ToString());

            Debug.Log("Windows Only:: Controller 1 Plugged in: " + 
				XCI.IsPluggedIn(XboxController.First).ToString());
            Debug.Log("Windows Only:: Controller 2 Plugged in: " + 
				XCI.IsPluggedIn(XboxController.Second).ToString());
            Debug.Log("Windows Only:: Controller 3 Plugged in: " + 
				XCI.IsPluggedIn(XboxController.Third).ToString());
            Debug.Log("Windows Only:: Controller 4 Plugged in: " + 
				XCI.IsPluggedIn(XboxController.Fourth).ToString());
        }
    }

    void Update()
    {
		foreach (RoleControl ctrl in m_AllCtrls)
		{
			ctrl.UpdateCtrl();
		}

        // Role role01 = Global.instance.m_Role01;
        // Role role02 = Global.instance.m_Role02;

        // if (role01 != null)
        // {
        //     // shoot
        //     if (Input.GetKeyDown(KeyCode.Space))
        //     {
        //         role01.Shoot();
        //     }
        // }
        // if (role02 != null)
        // {
        //     // shoot
        //     if (Input.GetKeyDown(KeyCode.Keypad0))
        //     {
        //         role02.Shoot();
        //     }
        // }
    }
}
