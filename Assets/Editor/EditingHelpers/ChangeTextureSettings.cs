
using UnityEngine;
using UnityEditor;

public class ChangeTextureSettings : ScriptableObject
{
	
	public delegate void ChangeImportSettings(TextureImporter import);
	
	public static void OptimizeTextureSelection(ChangeImportSettings c){
		
		
		AssetDatabase.StartAssetEditing();
			

		foreach(Object obj in Textures()){
			string path = AssetDatabase.GetAssetPath(obj);
			TextureImporter import = (TextureImporter)AssetImporter.GetAtPath(path);
			
			c(import);
			
			EditorUtility.SetDirty(obj);
			AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
		}
		
		EditorUtility.DisplayCancelableProgressBar("Optimizing stuff...", "Still gotta refresh, but hit revert when it asks.", 0.99f);
		
		AssetDatabase.StopAssetEditing();
		//AssetDatabase.Refresh();
		
		EditorUtility.ClearProgressBar();
		
	}
	
	[MenuItem ("Custom/Optimization/Set Textures 1024x1024", false, 1004)]
	public static void DoThingy1() {
		OptimizeTextureSelection(import => import.maxTextureSize = 1024);
	}

	
	[MenuItem ("Custom/Optimization/Set Textures 512x512", false, 1003)]
	public static void DoThingy2() {
		OptimizeTextureSelection(import => import.maxTextureSize = 512);
	}
	
	[MenuItem ("Custom/Optimization/Set Textures 256x256", false, 1002)]
	public static void DoThingy3() {
		OptimizeTextureSelection(import => import.maxTextureSize = 256);
	}
	
	[MenuItem ("Custom/Optimization/Reduce Texture Size By One Level", false, 1000)]
	public static void DoThingy4() {
		OptimizeTextureSelection(import => import.maxTextureSize = import.maxTextureSize / 2);
	}
	
	[MenuItem ("Custom/Optimization/RGB24", false, 951)]
	public static void DoThingy4b() {
		OptimizeTextureSelection(import => import.textureFormat = TextureImporterFormat.RGB24);
	}
	
	[MenuItem ("Custom/Optimization/RGBA32", false, 952)]
	public static void DoThingy4a() {
		OptimizeTextureSelection(import => import.textureFormat = TextureImporterFormat.RGBA32);
	}	
	[MenuItem ("Custom/Optimization/PVRTC_RGB2", false, 953)]
	public static void DoThingyPVRTC_RGB2() {
		OptimizeTextureSelection(import => import.textureFormat = TextureImporterFormat.PVRTC_RGB2);
	}	
	[MenuItem ("Custom/Optimization/PVRTC_RGB4", false, 954)]
	public static void DoThingyPVRTC_RGB4() {
		OptimizeTextureSelection(import => import.textureFormat = TextureImporterFormat.PVRTC_RGB4);
	}
	[MenuItem ("Custom/Optimization/PVRTC_RGBA2", false, 955)]
	public static void DoThingyPVRTC_PVRTC_RGBA2() {
		OptimizeTextureSelection(import => import.textureFormat = TextureImporterFormat.PVRTC_RGBA2);
	}	
	[MenuItem ("Custom/Optimization/PVRTC_RGBA4", false, 956)]
	public static void DoThingyPVRTC_RGBA4() {
		OptimizeTextureSelection(import => import.textureFormat = TextureImporterFormat.PVRTC_RGBA4);
	}
	
	[MenuItem ("Custom/Optimization/NonPower of 2", false, 1051)]
	public static void DoThingy4d() {
		OptimizeTextureSelection(import => import.npotScale = TextureImporterNPOTScale.None);
	}	
	
	[MenuItem ("Custom/Optimization/NPOT To Smaller", false, 1052)]
	public static void DoThingy4c() {
		OptimizeTextureSelection(import => import.npotScale = TextureImporterNPOTScale.ToSmaller);
	}
	
	[MenuItem ("Custom/Optimization/Increase Texture Size By One Level", false, 1001)]
	public static void DoThingy5() {
		foreach(Object obj in Textures()){
			string path = AssetDatabase.GetAssetPath(obj);
			TextureImporter import = (TextureImporter)AssetImporter.GetAtPath(path);
			
			import.maxTextureSize = import.maxTextureSize * 2;
			AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
		}
		
		AssetDatabase.Refresh();
	}
	
		
		
		
	[MenuItem ("Custom/Optimization/Texture Mipmaps On", false, 1010)]
	public static void DoThingy7() {
		foreach(Object obj in Textures()){
			string path = AssetDatabase.GetAssetPath(obj);
			TextureImporter import = (TextureImporter)AssetImporter.GetAtPath(path);
			
			import.mipmapEnabled = true;
			AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
		}
		
		AssetDatabase.Refresh();
	}
	
	[MenuItem ("Custom/Optimization/Texture Compression On", false, 1009)]
	public static void DoThingy77() {
		foreach(Object obj in Textures()){
			string path = AssetDatabase.GetAssetPath(obj);
			TextureImporter import = (TextureImporter)AssetImporter.GetAtPath(path);
			
			import.textureFormat = TextureImporterFormat.AutomaticCompressed;
			AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
		}
		
		AssetDatabase.Refresh();
	}
	
	[MenuItem ("Custom/Optimization/Texture Mipmaps Off", false, 1011)]
	public static void DoThingy6() {
		foreach(Object obj in Textures()){
			string path = AssetDatabase.GetAssetPath(obj);
			TextureImporter import = (TextureImporter)AssetImporter.GetAtPath(path);
			
			import.mipmapEnabled = false;
			AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
		}
		
		AssetDatabase.Refresh();
	}

	
	[MenuItem ("Custom/Optimization/Texture for GUI use", false, 901)]
	public static void DoThingy88() {
		
		
		foreach(Object obj in Textures()){
			string path = AssetDatabase.GetAssetPath(obj);
			TextureImporter import = (TextureImporter)AssetImporter.GetAtPath(path);
			
			import.textureType = TextureImporterType.Advanced;
			import.textureFormat = TextureImporterFormat.AutomaticCompressed;
			import.npotScale = TextureImporterNPOTScale.None;
			import.wrapMode = TextureWrapMode.Clamp;
			import.anisoLevel = 0;
			import.mipmapEnabled = false;
			
			AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
		}
		
		//AssetDatabase.Refresh();
	}
	
			
	[MenuItem ("Custom/Optimization/Texture Advanced nonsquare 256, mips, RGB16", false, 931)]
	public static void DoThiaaaaangy7() {
		foreach(Object obj in Textures()){
			string path = AssetDatabase.GetAssetPath(obj);
			TextureImporter import = (TextureImporter)AssetImporter.GetAtPath(path);
			
			import.mipmapEnabled = true;
			import.textureType = TextureImporterType.Advanced;
			import.textureFormat = TextureImporterFormat.RGB16;
			import.wrapMode = TextureWrapMode.Clamp;
			import.anisoLevel = 0;
			import.maxTextureSize = 256;
			import.npotScale = TextureImporterNPOTScale.None;
		
			import.mipmapEnabled = true;
		
			AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
		}
		
		AssetDatabase.Refresh();
	}
	
	
	[MenuItem ("Custom/Optimization/Texture to Advanced, pvrtc 2bbp, no alpha, 256, Mips", false, 930)]
	public static void DoThingy8887() {
		Object[] textures = Textures();
		float i = 1f;
		float total = textures.Length;
		
		AssetDatabase.StartAssetEditing();
			
		foreach(Object obj in textures){
			if(EditorUtility.DisplayCancelableProgressBar("Optimizing shit...", "Processing: " + obj.name, i/total)){
				EditorUtility.DisplayCancelableProgressBar("Optimizing shit...", "CANCELING!!!", 0.99f);
				AssetDatabase.Refresh();
				EditorUtility.ClearProgressBar();
				return;
			}

			string path = AssetDatabase.GetAssetPath(obj);
			TextureImporter import = (TextureImporter)AssetImporter.GetAtPath(path);
			
			import.textureType = TextureImporterType.Advanced;
			import.textureFormat = TextureImporterFormat.PVRTC_RGB2;
			import.wrapMode = TextureWrapMode.Clamp;
			import.anisoLevel = 0;
			import.maxTextureSize = 256;
		
			import.mipmapEnabled = true;
		
			AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
			i+= 1f;
		}
		EditorUtility.DisplayCancelableProgressBar("Optimizing shit...", "I think the refresh is the long part.", 0.99f);
			
		AssetDatabase.StopAssetEditing();
		//AssetDatabase.Refresh();
		
		EditorUtility.ClearProgressBar();
	}
	
	private static Object[] Textures(){
		return Selection.GetFiltered(typeof(Texture), SelectionMode.DeepAssets);
	}
}
