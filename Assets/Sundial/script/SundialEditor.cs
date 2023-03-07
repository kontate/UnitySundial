using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Sundial))]
public class SundialEditor : EditorWindow
{
    private static RenderTexture _rt;
    private float _minxy;
    
    [MenuItem("Window/Sundial")]
    static void Open()
    {
        var window = GetWindow<SundialEditor>();
        window.titleContent = new GUIContent("Sundial");
    }

    private void Update()
    {
        
    }

    private void OnGUI()
    {
        if (!_rt)
            _rt = AssetDatabase.LoadAssetAtPath<RenderTexture>("Assets/Sundial/texture/SundialTexture.renderTexture");
        _minxy = Math.Min(position.height, position.width);
        EditorGUILayout.LabelField(new GUIContent(_rt),GUILayout.Width(_minxy) , GUILayout.Height(_minxy));
    }
}
