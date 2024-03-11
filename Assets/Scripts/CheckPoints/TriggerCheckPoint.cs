using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckPoint : MonoBehaviour
{
	[SerializeField] private GameObject checkPoint;
	[SerializeField] private Animator animator;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			animator.SetBool("viewPoint", true);
			animator.SetBool("notViewPoint", false);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			animator.SetBool("notViewPoint", true);
			animator.SetBool("viewPoint", false);
		}
	}
}
