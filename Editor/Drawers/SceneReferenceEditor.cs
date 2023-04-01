﻿using System;
using UnityEditor;
using UnityEngine;

namespace UnityTools.Runtime.Navigation
{
    /// <summary>
    /// Editor for a scene reference that can display error prompts and offer
    /// solutions when the scene is not valid.
    /// </summary>
    [CustomPropertyDrawer(typeof(SceneReference))]
    public class SceneReferenceEditor : PropertyDrawer
    {
        #region Constants
        
        private const string TooltipSceneMissing = "Scene is not in build settings.";
        private const string TooltipSceneDisabled = "Scene is not enebled in build settings.";
        private const string ErrorSceneMissing =
            "You are refencing a scene that is not added to the build. Add it to the editor build settings now?";
        private const string ErrorSceneDisabled =
            "You are refencing a scene that is not active the build. Enable it in the build settings now?";

        #endregion Constants
        
        #region Private Variables
        
        private SerializedProperty scene;
        private SerializedProperty sceneName;
        private SerializedProperty sceneIndex;
        private SerializedProperty sceneEnabled;
        private SceneAsset sceneAsset;
        private string sceneAssetPath;
        private string sceneAssetGUID;

        private GUIContent errorTooltip;
        private GUIStyle errorStyle;
        
        #endregion Private Variables
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            CacheProperties(property);
            UpdateSceneState();

            position = DisplayErrorsIfNecessary(position);

            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, scene, GUIContent.none, false);
            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
                CacheProperties(property);
                UpdateSceneState();
                Validate();
            }
            
            EditorGUI.EndProperty();
        }
        
        /// <summary>
        /// Cache all used properties as local variables so that they can be
        /// used by other methods. This needs to be called every frame since a
        /// PropertyDrawer can be reused on different properties.
        /// </summary>
        /// <param name="property">Property to search through.</param>
        private void CacheProperties(SerializedProperty property)
        {
            scene = property.FindPropertyRelative("scene");
            sceneName = property.FindPropertyRelative("sceneName");
            sceneIndex = property.FindPropertyRelative("_sceneIndex");
            sceneEnabled = property.FindPropertyRelative("_sceneEnabled");
            sceneAsset = scene.objectReferenceValue as SceneAsset;

            if (sceneAsset != null)
            {
                sceneAssetPath = AssetDatabase.GetAssetPath(scene.objectReferenceValue);
                sceneAssetGUID = AssetDatabase.AssetPathToGUID(sceneAssetPath);
            }
            else
            {
                sceneAssetPath = null;
                sceneAssetGUID = null;
            }
        }

        /// <summary>
        /// Updates the scene index and enabled flags of a scene property by
        /// scanning through the scenes in EditorBuildSettings.
        /// </summary>
        private void UpdateSceneState()
        {
            if (sceneAsset == null)
            {
                sceneName.stringValue = "";
                return;
            }
            
            var scenes = EditorBuildSettings.scenes;

            sceneIndex.intValue = -1;
            for (int i = 0; i < scenes.Length; i++)
            {
                if (scenes[i].guid.ToString() != sceneAssetGUID)
                    continue;
                
                if (sceneIndex.intValue != i)
                    sceneIndex.intValue = i;
                
                sceneEnabled.boolValue = scenes[i].enabled;

                if (!scenes[i].enabled) break;
                
                sceneName.stringValue = sceneAsset.name;

                return;
            }
        }

        /// <summary>
        /// Display a popup error message about the selected scene and respond
        /// to the user choice by either fixing the issue in the build
        /// settings, doing nothing, or opening the build settings.
        /// </summary>
        /// <param name="message">Message to display.</param>
        private void DisplaySceneErrorPrompt(string message)
        {
            var scenes = EditorBuildSettings.scenes;
            
            int choice = EditorUtility.DisplayDialogComplex("Scene Not In Build",
                message, "Yes", "No", "Open Build Settings");

            if (choice == 0)
            {
                int newCount = sceneIndex.intValue < 0 ? scenes.Length + 1 : scenes.Length;
                var newScenes = new EditorBuildSettingsScene[newCount];
                Array.Copy(scenes, newScenes, scenes.Length);

                if (sceneIndex.intValue < 0)
                {
                    newScenes[scenes.Length] = new EditorBuildSettingsScene(sceneAssetPath, true);
                    sceneIndex.intValue = scenes.Length;
                }

                newScenes[sceneIndex.intValue].enabled = true;
                EditorBuildSettings.scenes = newScenes;
            }
            else if (choice == 2)
            {
                EditorApplication.ExecuteMenuItem("File/Build Settings...");
            }
        }

        /// <summary>
        /// If there is anything wrong with the selected scene, this will
        /// display an error icon that the user can click on for more info.
        /// </summary>
        /// <param name="position">
        /// Full rect that will be used to draw the property.
        /// </param>
        /// <returns>
        /// The rect that should be used to draw the rest of the property. If
        /// there are no errors, this is the same as the input position Rect.
        /// Otherwise, it will be the input rect adjusted to fit the error.
        /// </returns>
        private Rect DisplayErrorsIfNecessary(Rect position)
        {
            if (errorStyle == null)
            {
                errorStyle = "CN EntryErrorIconSmall";
                errorTooltip = new GUIContent("", "error");
            }

            if (sceneAsset == null)
                return position;
            
            var warningRect = new Rect(position) {
                width = errorStyle.fixedWidth + 4
            };

            if (sceneIndex.intValue < 0)
            {
                errorTooltip.tooltip = TooltipSceneMissing;
                position.xMin = warningRect.xMax;   
                if (GUI.Button(warningRect, errorTooltip, errorStyle))
                {
                    DisplaySceneErrorPrompt(ErrorSceneMissing);
                }
            }
            else if (!sceneEnabled.boolValue)
            {
                errorTooltip.tooltip = TooltipSceneDisabled;
                position.xMin = warningRect.xMax;
                if (GUI.Button(warningRect, errorTooltip, errorStyle))
                {
                    DisplaySceneErrorPrompt(ErrorSceneDisabled);
                }
            }

            return position;
        }

        /// <summary>
        /// Validate any new values in the scene property. This will display
        /// popup errors if there are issues with the current value.
        /// </summary>
        private void Validate()
        {
            if (sceneAsset == null)
            {
                sceneName.stringValue = "";
                return;
            }
            
            var scenes = EditorBuildSettings.scenes;

            sceneIndex.intValue = -1;
            for (int i = 0; i < scenes.Length; i++)
            {
                if (scenes[i].guid.ToString() != sceneAssetGUID)
                    continue;
                
                if (sceneIndex.intValue != i)
                    sceneIndex.intValue = i;

                if (!scenes[i].enabled) break;
                
                sceneName.stringValue = sceneAsset.name;

                return;
            }

            DisplaySceneErrorPrompt(sceneIndex.intValue >= 0
                ? ErrorSceneDisabled
                : ErrorSceneMissing);
        }
    }
}