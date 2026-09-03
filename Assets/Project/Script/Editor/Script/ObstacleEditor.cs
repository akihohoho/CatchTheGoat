//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(Obstacle))]
//public class ObstacleEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        Obstacle obs = (Obstacle)target;

//        GUILayout.Label("Thiết kế khối gỗ (Click vào ô):", EditorStyles.boldLabel);
//        GUILayout.Space(10);

//        for (int y = 0; y < obs.gridSize; y++)
//        {
//            GUILayout.BeginHorizontal();
//            for (int x = 0; x < obs.gridSize; x++)
//            {
//                int index = y * obs.gridSize + x;
//                obs.grid[index] = GUILayout.Toggle(obs.grid[index], "", GUILayout.Width(25), GUILayout.Height(25));
//            }
//            GUILayout.EndHorizontal();
//        }

//        if (GUI.changed)
//        {
//            EditorUtility.SetDirty(obs);
//        }
//    }
//}