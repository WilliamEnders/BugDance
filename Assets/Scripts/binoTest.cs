using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class binoTest : MonoBehaviour {

	public bool look;


	[SerializeField] private CurveControlledBob m_HeadBob = new CurveControlledBob();
	[SerializeField] private float m_StepInterval;
	[SerializeField] private bool m_IsWalking;
	[SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;

	private Camera m_Camera;
	private CharacterController m_CharacterController;
	private Vector3 m_OriginalCameraPosition;

	// Use this for initialization
	private void Start()
	{
		look = false;

		m_CharacterController = transform.parent.GetComponent<CharacterController>();
		m_Camera = Camera.main;
		m_OriginalCameraPosition = m_Camera.transform.localPosition;
		m_HeadBob.Setup(m_Camera, m_StepInterval);

	}

	// Update is called once per frame
	void Update () {
		if(look){
			UpdateBinocPosition(0.5f);	
		}
	}

	private void UpdateBinocPosition(float speed)
	{
		Vector3 newCameraPosition;
		if (m_CharacterController.velocity.magnitude == 0 && m_CharacterController.isGrounded)
		{
			m_Camera.transform.localPosition =
				m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
					speed);
			newCameraPosition = m_Camera.transform.localPosition;
			newCameraPosition.y = m_Camera.transform.localPosition.y;
		}
		else
		{
			newCameraPosition = m_Camera.transform.localPosition;
			newCameraPosition.y = m_OriginalCameraPosition.y;
		}
		m_Camera.transform.localPosition = newCameraPosition;
	}

}
