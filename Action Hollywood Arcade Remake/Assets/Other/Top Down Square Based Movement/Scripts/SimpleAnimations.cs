using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hoey.Examples;

namespace Hoey.Examples
{
	/// <summary>
	/// Author: Mark Hoey
	/// Description: This script toggles certain states in the animator on based on where inputs are on or off
	/// </summary>
	[RequireComponent(typeof(Animator))]
	public class SimpleAnimations : MonoBehaviour 
	{
		Animator animator;

		private void Start()
		{
			animator = this.GetComponent<Animator>();
		}

		public void ToggleWalk()
		{
			animator.SetBool("isWalking", true);
			animator.SetBool("isIdle", false);
		}

		public void ToggleIdle()
		{
			animator.SetBool("isIdle", true);
			animator.SetBool("isWalking", false);
		}

	}
}