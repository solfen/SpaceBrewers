using UnityEditor;
using UnityEngine;

// IngredientDrawer
[CustomPropertyDrawer (typeof(SailorOderPriority))]
public class SailorOrderPriorityPropertyDrawer : PropertyDrawer {
	

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

		EditorGUI.BeginProperty (position, label, property);

        var typeRect = new Rect(position.x, position.y, 150, position.height);
        var priorityRect = new Rect(position.x + 150, position.y, position.width - 150, position.height);

        EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("type"), GUIContent.none);
        EditorGUI.PropertyField(priorityRect, property.FindPropertyRelative("priority"), GUIContent.none, true);
		
		EditorGUI.EndProperty ();
	}
}

/*[CustomPropertyDrawer(typeof(SailorActionMessage))]
public class SailorActionMessagePropertyDrawer : PropertyDrawer {


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

        EditorGUI.BeginProperty(position, label, property);

        var typeRect = new Rect(position.x, position.y, 150, position.height);
        var priorityRect = new Rect(position.x + 150, position.y, position.width - 150, position.height);

        EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("type"), GUIContent.none);
        EditorGUI.PropertyField(priorityRect, property.FindPropertyRelative("texts"), GUIContent.none);

        EditorGUI.EndProperty();
    }
}*/