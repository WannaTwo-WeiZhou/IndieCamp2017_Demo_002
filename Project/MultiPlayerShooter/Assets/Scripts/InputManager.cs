using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	
	void Update()
	{
		Role role01 = Global.instance.m_Role01;
		Role role02 = Global.instance.m_Role02;

		if (role01 != null)
		{
			// shoot
			if (Input.GetKeyDown(KeyCode.Space))
			{
				role01.Shoot();
			}
		}
		if (role02 != null)
		{
			// shoot
			if (Input.GetKeyDown(KeyCode.Keypad0))
			{
				role02.Shoot();
			}
		}
	}
}
