using UnityEngine;
using UnityEditor;
using System.Collections;

public class ApplyAll : ScriptableObject
{

	[MenuItem ("Selection/Apply All", false, 205)]
	static void Do()
	{
		foreach (GameObject instance in Selection.gameObjects) {
			PrefabUtility.ReplacePrefab(instance, PrefabUtility.GetPrefabParent(instance), ReplacePrefabOptions.ConnectToPrefab);
		}
	}
	
	[MenuItem ("Selection/Apply All", true, 205)]
	public static bool ValidateShowCount()
	{
		return Selection.activeGameObject;
	}

	
}

