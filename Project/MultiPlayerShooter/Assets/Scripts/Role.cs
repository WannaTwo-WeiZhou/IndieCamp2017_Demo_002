using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirType
{
    Up = 0,
    Left = 1,
    Down = 2,
    Right = 3
};

public class Role : MonoBehaviour
{
    public float m_ShootInterval = 0.5f;
    public float m_MoveVec = 1f;
    public GameObject m_Arrow;
    public Transform m_AtkStartPos;

    private IEnumerator m_IE_ContinuseShoot;
    private float m_NextShootTime;
    private int m_LeftShootTimes;
    private readonly int m_MaxLeftShootTimes = 0;

    void Awake()
    {
        m_LeftShootTimes = 0;
        m_NextShootTime = Time.time;
        m_IE_ContinuseShoot = null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Arrow arrowCO = other.GetComponent<Arrow>();
        if (arrowCO != null && arrowCO.m_Role != this)
        {
            Destroy(arrowCO.gameObject);
            this.GetHurt();
        }
    }

    private void GetHurt()
    {
        Debug.Log(gameObject.name + " get hurt!!!");
    }

    public void Shoot()
    {
        if (m_Arrow == null) return;

        if (Time.time < m_NextShootTime)
        {
            this.AddShootTimes();
            return;
        }
        m_NextShootTime = Time.time + m_ShootInterval;

        GameObject arrowGO = Instantiate(m_Arrow,
            m_AtkStartPos.position,
            transform.rotation);
        arrowGO.transform.SetParent(transform.parent);
        Arrow arrowCO = arrowGO.GetComponent<Arrow>();
        arrowCO.Init(this, m_AtkStartPos.localPosition);
    }

    private void AddShootTimes()
    {
        m_LeftShootTimes++;
        m_LeftShootTimes = Mathf.Clamp(m_LeftShootTimes,
            0, m_MaxLeftShootTimes);

        this.CheckLeftShootTimes();
    }

    private void CheckLeftShootTimes()
    {
        if (m_LeftShootTimes > 0)
        {
            if (m_IE_ContinuseShoot == null)
            {
                m_IE_ContinuseShoot = IE_ContinuseShoot();
                StartCoroutine(m_IE_ContinuseShoot);
            }
        }
    }

    private IEnumerator IE_ContinuseShoot()
    {
        yield return new WaitForSeconds(m_NextShootTime - Time.time);

        this.Shoot();

        StopCoroutine(m_IE_ContinuseShoot);
        m_IE_ContinuseShoot = null;

        m_LeftShootTimes--;
        this.CheckLeftShootTimes();
    }

    public void Move(Vector2 vec)
    {
        // Debug.Log(gameObject.name + " Move(" + vec + ")");

        if (Mathf.Abs(vec.x) > Mathf.Abs(vec.y))
        {
            if (vec.x > 0)
            {
                vec = Vector2.right;
            }
            else
            {
                vec = Vector2.left;
            }
        }
        else
        {
            if (vec.y > 0)
            {
                vec = Vector2.up;
            }
            else
            {
                vec = Vector2.down;
            }
        }

        transform.Translate(vec * m_MoveVec * Time.deltaTime, Space.World);
    }
    public void Turn(Vector2 vec)
    {
        // Debug.Log(gameObject.name + " Turn(" + vec + ")");

        if (Mathf.Abs(vec.x) > Mathf.Abs(vec.y))
        {
            if (vec.x > 0)
            {
                vec = Vector2.right;
            }
            else
            {
                vec = Vector2.left;
            }
        }
        else
        {
            if (vec.y > 0)
            {
                vec = Vector2.up;
            }
            else
            {
                vec = Vector2.down;
            }
        }

        float ang = Vector2.Angle(vec, Vector2.up);
        if (vec.x > 0)
            ang = -ang;

        transform.SetLocalEulerAngles_Z(ang);
        // Debug.Log(gameObject.name + "'s ang = " + ang);
    }
}
