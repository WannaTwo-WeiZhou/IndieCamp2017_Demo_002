using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Arrow : MonoBehaviour
{

	public float m_Vec = 1f;

	[HideInInspector]
	public Role m_Role;

	private Vector2 m_Dir;

	void Start()
	{
		Destroy(gameObject, 3f);
	}

	void Update()
	{
		// Vector2 dir = new Vector2(
		// 	-Mathf.Tan(transform.localEulerAngles.z), 1);
		// dir = dir.normalized;
		transform.Translate(m_Dir * m_Vec * Time.deltaTime);
	}

	public void Init(Role role, Vector2 dir)
	{
		m_Role = role;
		m_Dir = dir;
	}
}
