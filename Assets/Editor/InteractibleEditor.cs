
using UnityEditor;
[CustomEditor(typeof(Interactable),true)]

public class InteractibleEditor : Editor
{
    // Start is called before the first frame update
   public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        if (target.GetType() == typeof(EventOnlyInteract))
        {
            interactable.promptMessage = EditorGUILayout.TextField("prompt message", interactable.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use UnityEvents.", MessageType.Info);
            if (interactable.GetComponent<InterationEvent>() ==null)
            {
                interactable.useEvents = true;
                interactable.gameObject.AddComponent<InterationEvent>();
            }
        }
        else
        {


            base.OnInspectorGUI();
            if (interactable.useEvents)
            {
                if (interactable.GetComponent<InterationEvent>() == null)
                    interactable.gameObject.AddComponent<InterationEvent>();
            }
            else
            {
                if (interactable.GetComponent<InterationEvent>() != null)
                    DestroyImmediate(interactable.GetComponent<InterationEvent>());

            }
        }
    }
}
