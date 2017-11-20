using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
	public static Global instance { get; private set;}

	public Role m_Role01;
	public Role m_Role02;

	protected void OnEnable()
	{
		if (Global.instance == null)
		{
			Global.instance = this;
		}
		else if (Global.instance != this)
		{
			Destroy(gameObject);
		}
	}

}
