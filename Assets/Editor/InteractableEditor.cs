using UnityEditor;

[CustomEditor(typeof(Interactable),true)]
public class InteractableEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.promptMessage = EditorGUILayout.TextField("Promt Message", interactable.promptMessage);
            EditorGUILayout.HelpBox("EventONly INteract caN ONLY USE UNITYEVENTS.",MessageType.Info);
            if(interactable.GetComponent<InteractionEvent>() == null)
            {

                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InteractionEvent>();
            }

        }
        else
        {
            base.OnInspectorGUI();
            if (interactable.useEvents)
            {
                if (interactable.GetComponent<InteractionEvent>() == null)
                    interactable.gameObject.AddComponent<InteractionEvent>();
            }
            else
            {
                if (interactable.GetComponent<InteractionEvent>() != null)
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>());
            }
        }
    }
}
