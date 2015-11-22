using UnityEngine;
using System.Collections;

public class TitleBird : SingletonScript<TitleBird> {

	public Animator animator;

	public void Start(){
		animator.SetFloat ("Flapping", 30.0f);
		animator.SetFloat ("dot", 10.0f);
		animator.SetFloat ("flapSpeed", 0.5f);

	}



}
