using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    public TextAsset inkJSON; 

    void OnMouseDown()
    {
        
        if (!DialogueManager.Instance.IsDialoguePlaying)
        {
            DialogueManager.Instance.EnterDialogueMode(inkJSON);
        }
    }
}
