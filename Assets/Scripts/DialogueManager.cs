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
        currentStory = null;
    }
}
