using UnityEngine;
using System.Collections;

public class NPCFinalInteract : MonoBehaviour
{
    [System.Serializable]
    public class EndingPath
    {
        public TextAsset inkJSON;
        public string requiredStat; 
        public int minValue;
    }

    public EndingPath[] endings; 
    public float returnToMenuDelay = 5f; 

    private bool hasInteracted = false;

    void OnMouseDown()
    {
        if (hasInteracted || DialogueManager.Instance.IsDialoguePlaying)
            return;

        foreach (EndingPath path in endings)
        {
            int statValue = GetStatValue(path.requiredStat);

            if (statValue >= path.minValue)
            {
                hasInteracted = true;
                DialogueManager.Instance.EnterDialogueMode(path.inkJSON);
                StartCoroutine(ReturnToMainMenuAfterDelay());
                return;
            }
        }

        Debug.Log("No valid ending met. Stats too low.");
    }

    int GetStatValue(string stat)
    {
        switch (stat.ToLower())
        {
            case "empathy": return PlayerStats.Instance.empathy;
            case "curiosity": return PlayerStats.Instance.curiosity;
            case "defiance": return PlayerStats.Instance.defiance;
            case "resolve": return PlayerStats.Instance.resolve;
            case "corruption": return PlayerStats.Instance.corruption;
            case "amulet": return PlayerStats.Instance.amulet;
            default: return 0;
        }
    }

    IEnumerator ReturnToMainMenuAfterDelay()
    {
        // Wait until dialogue ends before continuing
        while (DialogueManager.Instance.IsDialoguePlaying)
            yield return null;

        yield return new WaitForSeconds(returnToMenuDelay);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
