using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONtoDialogue : MonoBehaviour
{
    public TextAsset dialogues;
    public StorySO story;

    public ListOfRawDialogues dList = new ListOfRawDialogues();

    [Header("Portraits")]
    [Header("Meemaw")]
    public Sprite Meemaw_apologetic;
    public Sprite Meemaw_completely_neutral;
    public Sprite Meemaw_dissapointed;
    public Sprite Meemaw_explaining;
    public Sprite Meemaw_happy;
    public Sprite Meemaw_loving_proud;
    public Sprite Meemaw_neutral_smile;
    public Sprite Meemaw_questioning;
    public Sprite Meemaw_sad;
    public Sprite Meemaw_shocked;
    public Sprite Meemaw_surprised;
    public Sprite Meemaw_thinking;
    [Header("George")]
    public Sprite George_loving;
    public Sprite George_neutral;
    public Sprite George_sad;
    public Sprite George_thinking;
    [Header("Bruce")]
    public Sprite Bruce_angry;
    public Sprite Bruce_happy;
    public Sprite Bruce_neutral;
    public Sprite Bruce_sad;
    public Sprite Bruce_thinking;
    [Header("Charlotte")]
    public Sprite Charlotte_angry;
    public Sprite Charlotte_happy;
    public Sprite Charlotte_neutral;
    public Sprite Charlotte_sad;
    public Sprite Charlotte_thinking;
    [Header("Edith")]
    public Sprite Edith_angry;
    public Sprite Edith_happy;
    public Sprite Edith_neutral;
    public Sprite Edith_sad;
    public Sprite Edith_smirking;
    public Sprite Edith_thinking;
    [Header("Jasper")]
    public Sprite Jasper_angry;
    public Sprite Jasper_concerned;
    public Sprite Jasper_evil;
    public Sprite Jasper_happy;
    public Sprite Jasper_neutral;
    public Sprite Jasper_sad;
    public Sprite Jasper_smirk;
    public Sprite Jasper_thinking;
    [Header("Martha")]
    public Sprite Martha_angry;
    public Sprite Martha_happy;
    public Sprite Martha_neutral;
    public Sprite Martha_sad;
    public Sprite Martha_thinking;

    [Header("Initiators")]
    public GhostSO george;
    public GhostSO bruce;
    public GhostSO charlotte;
    public GhostSO edith;
    public GhostSO jasper;
    public GhostSO martha;
    private GhostSO currentInitiator;

    [Header("Events")]
    public IntGameEvent nextStoryPoint;
    public IntGameEvent StoryPrompt;
    public IntGameEvent Sudoku;
    public IntGameEvent level_world;
    public IntGameEvent level_bruce;
    public IntGameEvent level_charlotte;
    public IntGameEvent level_edith;
    public IntGameEvent level_jasper;
    public IntGameEvent level_martha;
    public IntGameEvent level_Husband;
    public IntGameEvent mainMenu;
    public IntGameEvent endCutscene;





    private void Start()
    {
        dList = JsonUtility.FromJson<ListOfRawDialogues>(dialogues.text);

        Debug.Log("Story Points Cleared");
        story.ClearList();

        currentInitiator = george;
        foreach(RawDialogue rawDialogue in dList.Dialogue)
        {
            StoryPointSO dialogue = StoryPointSO.CreateInstance<StoryPointSO>();
            dialogue.character = rawDialogue.Character;
            dialogue.description = "Auto Generated";
            dialogue.text = rawDialogue.Text;

            //Portait
            dialogue.rightSidePortrait = false;
            switch(rawDialogue.Character)
            {
                case "Meemaw":
                    dialogue.rightSidePortrait = true;
                    switch(rawDialogue.Emotion)
                    {
                        case "Apologetic":
                            dialogue.portrait = Meemaw_apologetic;
                            break;
                        case "Disappointed":
                            dialogue.portrait = Meemaw_dissapointed;
                            break;
                        case "Explaining":
                            dialogue.portrait = Meemaw_explaining;
                            break;
                        case "Happy":
                            dialogue.portrait = Meemaw_happy;
                            break;
                        case "Loving/Proud":
                            dialogue.portrait = Meemaw_loving_proud;
                            break;
                        case "Neutral/Smile":
                            dialogue.portrait = Meemaw_neutral_smile;
                            break;
                        case "Neutral":
                            dialogue.portrait = Meemaw_completely_neutral;
                            break;
                        case "Questioning":
                            dialogue.portrait = Meemaw_questioning;
                            break;
                        case "Sad":
                            dialogue.portrait = Meemaw_sad;
                            break;
                        case "Shocked":
                            dialogue.portrait = Meemaw_shocked;
                            break;
                        case "Suprised":
                            dialogue.portrait = Meemaw_surprised;
                            break;
                        case "Thinking":
                            dialogue.portrait = Meemaw_thinking;
                            break;
                        case "Thoughtful":
                            dialogue.portrait = Meemaw_thinking;
                            break;
                        case "Loving":
                            dialogue.portrait = Meemaw_loving_proud;
                            break;
                        case "Awkward":
                            dialogue.portrait = Meemaw_apologetic;
                            break;
                        case "Concerned":
                            dialogue.portrait = Meemaw_questioning;
                            break;
                        case "Worried":
                            dialogue.portrait = Meemaw_apologetic;
                            break;
                        default:
                            Debug.LogWarning($"Missing case for {rawDialogue.Character}s {rawDialogue.Emotion} emotion");
                            break;
                    }
                    break;
                case "George":
                    switch (rawDialogue.Emotion)
                    {
                        case "Loving":
                            dialogue.portrait = George_loving;
                            break;
                        case "Happy":
                            dialogue.portrait = George_loving;
                            break;
                        case "Neutral":
                            dialogue.portrait = George_neutral;
                            break;
                        case "Sad":
                            dialogue.portrait = George_sad;
                            break;
                        case "Questioning":
                            dialogue.portrait = George_thinking;
                            break;
                        default:
                            Debug.LogWarning($"Missing case for {rawDialogue.Character}s {rawDialogue.Emotion} emotion");
                            break;
                    }
                    break;
                case "Charlotte":
                    switch (rawDialogue.Emotion)
                    {
                        case "Angry":
                            dialogue.portrait = Charlotte_angry;
                            break;
                        case "Happy":
                            dialogue.portrait = Charlotte_happy;
                            break;
                        case "Neutral":
                            dialogue.portrait = Charlotte_neutral;
                            break;
                        case "Sad":
                            dialogue.portrait = Charlotte_sad;
                            break;
                        case "Thoughtful":
                            dialogue.portrait = Charlotte_thinking;
                            break;
                        default:
                            Debug.LogWarning($"Missing case for {rawDialogue.Character}s {rawDialogue.Emotion} emotion");
                            break;
                    }
                    break;
                case "Edith":
                    switch (rawDialogue.Emotion)
                    {
                        case "Angry":
                            dialogue.portrait = Edith_angry;
                            break;
                        case "Happy":
                            dialogue.portrait = Edith_happy;
                            break;
                        case "Neutral":
                            dialogue.portrait = Edith_neutral;
                            break;
                        case "Sad":
                            dialogue.portrait = Edith_sad;
                            break;
                        case "Smirk":
                            dialogue.portrait = Edith_smirking;
                            break;
                        case "Thinking":
                            dialogue.portrait = Edith_thinking;
                            break;
                        case "Questioning":
                            dialogue.portrait = Edith_thinking;
                            break;
                        default:
                            Debug.LogWarning($"Missing case for {rawDialogue.Character}s {rawDialogue.Emotion} emotion");
                            break;
                    }
                    break;
                case "Jasper":
                    switch (rawDialogue.Emotion)
                    {
                        case "Angry":
                            dialogue.portrait = Jasper_angry;
                            break;
                        case "Concerned":
                            dialogue.portrait = Jasper_concerned;
                            break;
                        case "Evil":
                            dialogue.portrait = Jasper_evil;
                            break;
                        case "Evil Smirk":
                            dialogue.portrait = Jasper_evil;
                            break;
                        case "Happy":
                            dialogue.portrait = Jasper_happy;
                            break;
                        case "Neutral":
                            dialogue.portrait = Jasper_neutral;
                            break;
                        case "Sad":
                            dialogue.portrait = Jasper_sad;
                            break;
                        case "Smirk":
                            dialogue.portrait = Jasper_smirk;
                            break;
                        case "Thinking":
                            dialogue.portrait = Jasper_thinking;
                            break;
                        case "Questioning":
                            dialogue.portrait = Jasper_thinking;
                            break;
                        default:
                            Debug.LogWarning($"Missing case for {rawDialogue.Character}s {rawDialogue.Emotion} emotion");
                            break;
                    }
                    break;
                case "Martha":
                    switch (rawDialogue.Emotion)
                    {
                        case "Angry":
                            dialogue.portrait = Martha_angry;
                            break;
                        case "Happy":
                            dialogue.portrait = Martha_happy;
                            break;
                        case "Neutral":
                            dialogue.portrait = Martha_neutral;
                            break;
                        case "Sad":
                            dialogue.portrait = Martha_sad;
                            break;
                        case "Thinking":
                            dialogue.portrait = Martha_thinking;
                            break;
                        case "Questioning":
                            dialogue.portrait = Martha_thinking;
                            break;
                        default:
                            Debug.LogWarning($"Missing case for {rawDialogue.Character}s {rawDialogue.Emotion} emotion");
                            break;
                    }
                    break;
                case "Bruce":
                    switch (rawDialogue.Emotion)
                    {
                        case "Angry":
                            dialogue.portrait = Bruce_angry;
                            break;
                        case "Happy":
                            dialogue.portrait = Bruce_happy;
                            break;
                        case "Neutral":
                            dialogue.portrait = Bruce_neutral;
                            break;
                        case "Sad":
                            dialogue.portrait = Bruce_sad;
                            break;
                        case "Thinking":
                            dialogue.portrait = Bruce_thinking;
                            break;
                        case "Questioning":
                            dialogue.portrait = Bruce_thinking;
                            break;
                        default:
                            Debug.LogWarning($"Missing case for {rawDialogue.Character}s {rawDialogue.Emotion} emotion");
                            break;
                    }
                    break;
            }

            //Events
            dialogue.Events = new List<IntGameEvent>();
            foreach(string myEvent in rawDialogue.Events)
            {
                switch(myEvent)
                {
                    case "":
                        dialogue.Events.Add(nextStoryPoint);
                        dialogue.Events.Add(StoryPrompt);
                        break;
                    case "NextStroyPoint":
                        dialogue.Events.Add(nextStoryPoint);
                        dialogue.Events.Add(StoryPrompt);
                        break;
                    case "Sudoku":
                        dialogue.Events.Add(Sudoku);
                        break;
                    case "Scene":
                        dialogue.Events.Add(level_world);
                        break;
                    case "GeorgeLevel":
                        dialogue.Events.Add(level_Husband);
                        break;
                    case "BruceLevel":
                        dialogue.Events.Add(level_bruce);
                        break;
                    case "CharlotteLevel":
                        dialogue.Events.Add(level_charlotte);
                        break;
                    case "EdithLevel":
                        dialogue.Events.Add(level_edith);
                        break;
                    case "JasperLevel":
                        dialogue.Events.Add(level_jasper);
                        break;
                    case "MarthaLevel":
                        dialogue.Events.Add(level_martha);
                        break;
                    case "George":
                        dialogue.Events.Add(nextStoryPoint);
                        currentInitiator = george;
                        break;
                    case "Bruce":
                        dialogue.Events.Add(nextStoryPoint);
                        currentInitiator = bruce;
                        break;
                    case "Charlotte":
                        dialogue.Events.Add(nextStoryPoint);
                        currentInitiator = charlotte;
                        break;
                    case "Edith":
                        dialogue.Events.Add(nextStoryPoint);
                        currentInitiator = edith;
                        break;
                    case "Jasper":
                        dialogue.Events.Add(nextStoryPoint);
                        currentInitiator = jasper;
                        break;
                    case "Martha":
                        dialogue.Events.Add(nextStoryPoint);
                        currentInitiator = martha;
                        break;
                    case "End":
                        dialogue.Events.Add(endCutscene);
                        break;
                    default:
                        Debug.LogWarning($"No event linked to '{myEvent}'");
                        break;
                        
                }
            }
            dialogue.Initiator = currentInitiator;

            //Debug.Log(dialogue.GetType());
            story.AddStoryPoint(dialogue);
        }
    }
}


[System.Serializable]
public class RawDialogue
{
    public string Character;
    public string Emotion;
    public string Text;
    public string[] Events;
}

[System.Serializable]
public class ListOfRawDialogues
{
    public List<RawDialogue> Dialogue;
}
