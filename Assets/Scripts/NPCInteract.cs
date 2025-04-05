using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    public TextAsset inkJSON; // Your compiled ink story file

    void OnMouseDown()
    {
        // Make sure this only happens if the player isn't already in dialogue
        if (!DialogueManager.Instance.IsDialoguePlaying)
        {
            DialogueManager.Instance.EnterDialogueMode(inkJSON);
        }
    }
}
