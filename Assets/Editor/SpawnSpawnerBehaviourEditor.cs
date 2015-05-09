using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnSpawnerBehaviour))]
public class SpawnSpawnerBehaviourEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		SpawnSpawnerBehaviour spawnSpawnerBehaviour = (SpawnSpawnerBehaviour)target;
		if(GUILayout.Button("Spawn"))
		{
			spawnSpawnerBehaviour.SpawnButton();
		}
	}
	
}
