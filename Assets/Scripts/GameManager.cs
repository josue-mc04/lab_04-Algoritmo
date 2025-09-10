using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public CustomDoubleLinkedList dialogs = new();
    public TMP_Text dialogText;

    private Node<Dialogo> current;

    void Start()
    {
        dialogs.AddNode(new Dialogo { texto = "Hello, welcome to the Pokemon world", emotion = Emotion.Happy });
        dialogs.AddNode(new Dialogo { texto = "My name is Oak, and I'll be your guide on this journey.", emotion = Emotion.Happy });
        dialogs.AddNode(new Dialogo { texto = "Are you ready for this adventure?", emotion = Emotion.Happy });
        dialogs.AddNode(new Dialogo { texto = "Well, let's not waste any more time...?", emotion = Emotion.Happy });

        current = dialogs.Tail; // start with oldest dialog
        ShowCurrentDialog();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (current != null && current.Next != null)
            {
                current = current.Next;
                ShowCurrentDialog();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (current != null && current.Prev != null)
            {
                current = current.Prev;
                ShowCurrentDialog();
            }
        }
    }

    void ShowCurrentDialog()
    {
        if (current != null && dialogText != null)
        {
            dialogText.text = current.Value.GetDialog();
        }
    }
    public void ShowNexTex()
    {
        if (current != null && current.Prev != null)
        {
            current = current.Prev;
            ShowCurrentDialog();
        }
    }
    public void ShowFormerTex()
    {
           if (current != null && current.Next != null)
            {
                current = current.Next;
                ShowCurrentDialog();
            }
    }
}