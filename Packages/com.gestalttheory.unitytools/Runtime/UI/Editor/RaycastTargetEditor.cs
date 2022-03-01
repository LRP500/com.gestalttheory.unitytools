using System;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace UnityTools.Runtime.UI.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(RaycastTarget), false)]
    public class RaycastTargetEditor : GraphicEditor
    {
        public override void OnInspectorGUI ()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_Script, Array.Empty<GUILayoutOption>());
            RaycastControlsGUI();
            serializedObject.ApplyModifiedProperties();
        }
    }
}