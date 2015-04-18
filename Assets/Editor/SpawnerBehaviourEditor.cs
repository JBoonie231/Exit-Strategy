using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnerBehaviour))]
public class SpawnerBehaviourEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		SpawnerBehaviour spawnerBehaviour = (SpawnerBehaviour)target;
		if(GUILayout.Button("Spawn"))
		{
			spawnerBehaviour.SpawnButton();
		}
	}

}
