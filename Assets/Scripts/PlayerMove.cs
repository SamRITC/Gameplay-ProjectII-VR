// Author: Sam Patterson
// C00203377 ITC Gameplay Project 2 VR
// Player Movement Script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public GameObject m_ground;
    private bool m_walking = false;
    private Vector3 m_spawnPos;

	// Use this for initialization
	void Start () {
        m_spawnPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        // if m_walking is true, move the camera (our VR head) forward
		if (m_walking)
        {
            transform.position = transform.position + Camera.main.transform.forward * 1f * Time.deltaTime;
        }

        // if we fall off the edge, respawn
        if (transform.position.y < -10.0f)
        {
            transform.position = m_spawnPos;
        }

        // do a ray cast to see if we're looking at the ground. If we're looking at the ground we're going to stop walking.
        Ray m_ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit m_rayHit;

        if (Physics.Raycast (m_ray, out m_rayHit))
        {
            if (m_rayHit.collider.name.Contains("Floor"))
            {
                m_walking = false;
            }

        }
        else
        {
            m_walking = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            print("Enemy Encountered!");
            transform.position = m_spawnPos;
        }

        if (collision.transform.tag == "Goal")
        {
            print("Goal Encountered!");
            Manager.CompleteLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Goal")
        {
            print("Goal Encountered!");
            Manager.CompleteLevel();
        }
    }
}
