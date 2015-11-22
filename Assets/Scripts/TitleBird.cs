using UnityEngine;
using System.Collections;

public class TitleBird : SingletonScript<TitleBird> {

	public Animator animator;

	public void Start(){
		animator.SetFloat ("Flapping", 1.0f);

	}



}
