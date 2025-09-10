using UnityEngine;

public class CustomDoubleLinkedList : DoubleLinkedList<Dialogo>
{
    public void ShowHistoryForward(int depth = 1000)
    {
        ShowForward(Tail, depth);
    }

    public void ShowHistoryBackward(int depth = 1000)
    {
        ShowBackward(Head, depth);
    }

    private void ShowForward(Node<Dialogo> current, int depth)
    {
        if (current == null || depth <= 0) return;

        Debug.Log(current.Value.GetDialog());
        if (current.Next != null)
            ShowForward(current.Next, depth - 1);
    }

    private void ShowBackward(Node<Dialogo> current, int depth)
    {
        if (current == null || depth <= 0) return;

        Debug.Log(current.Value.GetDialog());
        if (current.Prev != null)
            ShowBackward(current.Prev, depth - 1);
    }
}