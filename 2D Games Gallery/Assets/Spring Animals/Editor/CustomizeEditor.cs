using UnityEngine;
using System.Collections;
using UnityEditor;

namespace MadFireOn
{

    [CustomEditor(typeof(GameManager_SpringAnimals))]
    public class CustomizeEditor_SpringAnimals : Editor
    {

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameManager_SpringAnimals myTarget = (GameManager_SpringAnimals)target;

            if (GUILayout.Button("Reset All"))
            {
                myTarget.ResetGameManager();
            }
            
        }

    }
}//namespace MadFireOn
