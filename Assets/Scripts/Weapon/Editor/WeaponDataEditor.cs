using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Powerfish.WeaponSystem;
using Powerfish.WeaponSystem.Components;

namespace Powerfish
{
    [CustomEditor(typeof(WeaponData))]
    public class WeaponDataEditor : Editor
    {
        private static List<Type> dataCompTypes = new List<Type>();
        private WeaponData weaponData;

        private bool showForceUpdateButtons;
        private bool showAddComponentButtons;

        private void OnEnable()
        {
            weaponData = target as WeaponData;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            showAddComponentButtons = EditorGUILayout.Foldout(showAddComponentButtons, "Add Components");

            if (showAddComponentButtons)
            {
                DrawAddComponentButtons();
            }

            showForceUpdateButtons = EditorGUILayout.Foldout(showForceUpdateButtons, "Force Update Buttons");

            if (showForceUpdateButtons)
            {
                if (GUILayout.Button("Force Update Component Names"))
                {
                    foreach (var item in weaponData.componentData)
                    {
                        item.SetComponentName();
                    }
                }
            }
        }

        private void DrawAddComponentButtons()
        {
            foreach (var dataCompType in dataCompTypes)
            {
                if (GUILayout.Button("Add " + dataCompType.Name))
                {
                    AddComponentToWeaponData(dataCompType);
                }
            }
        }

        private void AddComponentToWeaponData(Type dataCompType)
        {
            var component = Activator.CreateInstance(dataCompType) as ComponentData;
            if (component != null)
            {
                weaponData.AddData(component);
                EditorUtility.SetDirty(weaponData);
            }
        }

        [DidReloadScripts]
        private static void OnRecompile()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());

            // Filter all the subclass of ComponentData
            var filteredTypes = types.Where(
                type => type.IsSubclassOf(typeof(ComponentData)) && !type.ContainsGenericParameters && type.IsClass
            );

            dataCompTypes = filteredTypes.ToList();
        }
    }
}
