
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections.Generic;

public class RandomizeSprites : EditorWindow 
{
	static RandomizeSprites window;
	private static List<Sprite> o;

	[MenuItem ("GG/Randomize Sprites", false, 3)]
	static void Execute ()
	{
		o = new List<Sprite> ();
		if (window == null)
			window = (RandomizeSprites)GetWindow (typeof(RandomizeSprites));
		window.Show ();
	}

	void OnGUI ()
	{
		if (o == null)
			o = new List<Sprite> ();
		
		for(int i = 0; i < 10; i++){
			Sprite current = null;
			if (o.Count > i) {
				current = o [i];
			}
			Sprite obj = EditorGUILayout.ObjectField (current, typeof(Sprite), true) as Sprite;
			if (obj != null) {
				if (o.Count <= i) {
					o.Add (obj);
				}
				o [i] = obj;
			}
		}


		EditorGUILayout.Separator ();
		GUILayout.Label ("Select a bunch of game objects and the above sprites will be randomly applied.");

		if (GUILayout.Button ("Apply")) {
			foreach (Transform t in Selection.transforms) {
				SpriteRenderer sr = t.GetComponent<SpriteRenderer> ();
				if (sr != null) {
					sr.sprite = o [UnityEngine.Random.Range (0, o.Count)];
				}
			}
		}

	}

}