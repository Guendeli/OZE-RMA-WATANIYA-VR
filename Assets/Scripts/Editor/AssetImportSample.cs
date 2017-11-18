using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetImportSample : AssetPostprocessor {

    void OnPreprocessTexture()
    {
        if (assetPath.Contains("_UI") || assetPath.Contains("_Sprite"))
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spriteImportMode = SpriteImportMode.Multiple;
            textureImporter.mipmapEnabled = false; // we don't need mipmaps for 2D/UI Atlases

            if (textureImporter.isReadable)
            {
                textureImporter.isReadable = false; // make sure Read/Write is disabled
            }
            textureImporter.maxTextureSize = 1024; // force a max texture size
            Debug.Log("UI/Sprite Audit Complete");
        }
    }
}
