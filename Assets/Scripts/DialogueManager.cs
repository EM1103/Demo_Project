using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public Transform choicesContainer;
    public GameObject choiceButtonPrefab;

    private Story currentStory;
    public bool IsDialoguePlaying { get; private set; }

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;

        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (!IsDialoguePlaying) return;

        if (Input.GetMouseButtonDown(0) && currentStory.currentChoices.Count == 0)
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);

        // Inject player stats
        currentStory.variablesState["empathy"] = PlayerStats.Instance.empathy;
        currentStory.variablesState["curiosity"] = PlayerStats.Instance.curiosity;
        currentStory.variablesState["defiance"] = PlayerStats.Instance.defiance;
        currentStory.variablesState["resolve"] = PlayerStats.Instance.resolve;
        currentStory.variablesState["corruption"] = PlayerStats.Instance.corruption;

        // Inject chapter keys
        currentStory.variablesState["key_p"] = PlayerStats.Instance.key_p;
        currentStory.variablesState["key_1"] = PlayerStats.Instance.key_1;
        currentStory.variablesState["key_2"] = PlayerStats.Instance.key_2;
        currentStory.variablesState["key_3"] = PlayerStats.Instance.key_3;
        currentStory.variablesState["key_4"] = PlayerStats.Instance.key_4;
        currentStory.variablesState["key_5"] = PlayerStats.Instance.key_5;
        
        IsDialoguePlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    void DisplayChoices()
    {
        foreach (Transform child in choicesContainer)
            Destroy(child.gameObject);

        foreach (Choice choice in currentStory.currentChoices)
        {
            GameObject choiceBtn = Instantiate(choiceButtonPrefab, choicesContainer);
            TMP_Text btnText = choiceBtn.GetComponentInChildren<TMP_Text>();
            btnText.text = choice.text.Trim();

            choiceBtn.GetComponent<Button>().onClick.AddListener(() =>
            {
                currentStory.ChooseChoiceIndex(choice.index);
                ContinueStory();
            });
        }
    }

    void ExitDialogueMode()
    {
        IsDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        // Sync updated Ink values back to PlayerStats
        PlayerStats.Instance.empathy = (int)currentStory.variablesState["empathy"];
        PlayerStats.Instance.curiosity = (int)currentStory.variablesState["curiosity"];
        PlayerStats.Instance.defiance = (int)currentStory.variablesState["defiance"];
        PlayerStats.Instance.resolve = (int)currentStory.variablesState["resolve"];
        PlayerStats.Instance.corruption = (int)currentStory.variablesState["corruption"];

        // Sync updated Ink values back to the chapter keys in PlayerStats
        PlayerStats.Instance.key_p = (int)currentStory.variablesState["key_p"];    
        PlayerStats.Instance.key_1 = (int)currentStory.variablesState["key_1"];
        PlayerStats.Instance.key_2 = (int)currentStory.variablesState["key_2"];
        PlayerStats.Instance.key_3 = (int)currentStory.variablesState["key_3"];
        PlayerStats.Instance.key_4 = (int)currentStory.variablesState["key_4"];
        PlayerStats.Instance.key_5 = (int)currentStory.variablesState["key_5"];    

        currentStory = null;
    }
}
