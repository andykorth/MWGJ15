using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

public class TexturePackerImporter : AssetPostprocessor
{
	
	void OnPreprocessTexture ()
	{
		TextureImporter importer = assetImporter as TextureImporter;
//		Debug.Log ("Preprocess: " + importer.assetPath);
		if (assetPath.Contains ("AutoAtlas")) {
			importer.textureType = TextureImporterType.Sprite;
			importer.maxTextureSize = 4096;
			importer.spriteImportMode = SpriteImportMode.Single;
//			importer.spritePivot = new Vector2 (0.5f, 1.0f);
			importer.textureFormat = TextureImporterFormat.RGBA32;
		}
	}

}
