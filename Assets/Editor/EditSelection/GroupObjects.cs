using UnityEngine;
using UnityEditor;
using System.Collections;

public class GroupObjects : ScriptableObject {

	[MenuItem("Selection/Group Selected GameObjects %g", false, 300)]
	static void GroupObjectsCommand() {
		GameObject mainSelection = Selection.activeGameObject;
		Transform selectionParent = mainSelection.transform.parent;
		
		Object[] objs = Selection.GetFiltered(typeof(GameObject), SelectionMode.Editable | SelectionMode.ExcludePrefab);
		
		GameObject parent = new GameObject(mainSelection.name + " Group");
		foreach (GameObject go in objs){
			go.transform.parent = parent.transform;
		}
		
		parent.transform.parent = selectionParent;
		Selection.activeGameObject = parent;
	}
	
	[MenuItem("Selection/Group Selected GameObjects %g", true, 300)]
	static bool ValidateGroupObjectsCommand() {
		Object[] objs = Selection.GetFiltered(typeof(GameObject), SelectionMode.Deep | SelectionMode.Editable | SelectionMode.ExcludePrefab);
		
		return objs != null && objs.Length > 0;
	}
	
	[MenuItem("Selection/Center on first child", false, 301)]
	static bool ValidateCenter() {
		Object[] objs = Selection.GetFiltered(typeof(GameObject), SelectionMode.Deep | SelectionMode.Editable | SelectionMode.ExcludePrefab);
		
		return objs != null && objs.Length > 0 && Selection.activeGameObject.transform.childCount >= 1;
	}
	
	[MenuItem("Selection/Center on first child", false, 301)]
	static void Center() {
		
		Object[] objs = Selection.GetFiltered(typeof(GameObject), SelectionMode.Editable | SelectionMode.ExcludePrefab);
		
		foreach (GameObject go in objs){
			Transform child = go.transform.GetChild(0);
			Vector3 childPos = child.position;
			go.transform.position = child.position;
			child.position = childPos;
		}
	}
	
	[MenuItem ("GameObject/Create Child GameObject %#m", false, 301)]
	static void doItMore()
	{
		GameObject child = new GameObject();
		child.transform.parent = ((GameObject)Selection.activeObject).transform;
		
		child.transform.localPosition = Vector3.zero;
		child.transform.rotation = Quaternion.identity;
		
		Selection.activeObject = child;
	}
	/*
	 Removed because these don't seem to do what they imply they do... It's caused some problems for people editing levels. 
	
	[MenuItem ("GameObject/Replace Parent (Reset Transform) &#r", false, 302)]
	static void ResetAndReplace()
	{
		Transform t = ((GameObject)Selection.activeObject).transform;
		
		// reset obj transform
		t.localPosition = Vector3.zero;
		t.localRotation = Quaternion.identity;
		t.localScale = Vector3.one;
		
		ReplaceParent();
	}


	[MenuItem ("GameObject/Replace Parent", false, 303)]
	static void ReplaceParent()
	{
		GameObject obj = (GameObject)Selection.activeObject;
		GameObject parent = (GameObject)obj.transform.parent.gameObject;
		
		// move children
		foreach(Transform child in parent.transform){
			if(obj == child) continue;
			child.parent = obj.transform;
		}
		
		// replace
		obj.transform.parent = parent.transform.parent;
		DestroyImmediate(parent);
		Selection.activeObject = obj;
	}
*/

}
