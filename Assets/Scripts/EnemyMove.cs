using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public Transform[] m_patrolPoints;
    public float m_moveSpeed;
    private int m_currentPoint;


	// Use this for initialization
	void Start () {
        transform.position = m_patrolPoints[0].position;
        m_currentPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position == m_patrolPoints[m_currentPoint].position)
        {
            m_currentPoint++;
        }

        if (m_currentPoint >= m_patrolPoints.Length)
        {
            m_currentPoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, m_patrolPoints[m_currentPoint].position, m_moveSpeed * Time.deltaTime);
	}
}
