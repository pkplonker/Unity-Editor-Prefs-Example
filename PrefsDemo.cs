using System;
using UnityEditor;
using UnityEngine;

public class PrefsDemo : EditorWindow
{
	private static bool firstBool;
	private static bool secondBool;
	private static float firstFloat;
	private static int firstInt;

	[MenuItem("Custom/Prefs Demo Window")]
	public static void ShowWindow() => GetWindow<PrefsDemo>("Prefs Demo Window");

	private void OnEnable() => LoadPrefs();

	private void OnDisable() => SavePrefs();

	private void LoadPrefs()
	{
		firstBool = EditorPrefs.GetBool("firstBool", false);
		secondBool = EditorPrefs.GetBool("secondBool", false);
		firstFloat = EditorPrefs.GetFloat("firstFloat", 1f);
		firstInt = EditorPrefs.GetInt("firstInt", 0);
	}

	private void SavePrefs()
	{
		EditorPrefs.SetBool("firstBool", firstBool);
		EditorPrefs.SetBool("secondBool", secondBool);
		EditorPrefs.SetFloat("firstFloat", firstFloat);
		EditorPrefs.SetInt("firstInt", firstInt);
	}

	private void OnGUI()
	{
		firstBool = EditorGUILayout.Toggle(new GUIContent("First Bool:"), firstBool);
		secondBool = EditorGUILayout.Toggle(new GUIContent("Second Bool:"), secondBool);
		firstFloat = EditorGUILayout.FloatField(new GUIContent("First Float:"), firstFloat);
		firstInt = EditorGUILayout.IntField(new GUIContent("First Int:"), firstInt);

		if (GUI.changed)
		{
			SavePrefs();
		}
	}
}
