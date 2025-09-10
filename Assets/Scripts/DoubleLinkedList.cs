using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
public class DoubleLinkedList<T>
{
    public Node<T> Head = null;
    public Node<T> Tail = null;
    public int Count;

    public virtual void AddNode(T dato)
    {
        Node<T> newNode = new Node<T>(dato);
        #region Caso de primer elemento
        if (Head == null && Tail == null)
        {
            Head = newNode;
            Tail = newNode;
            Count++;
            return;
        }
        #endregion
        #region Case de dos a mas elementos
        if(Head != null)
        {
            newNode.SetNext(Head);
            Head.SetPrev(newNode);

            Head = newNode;
            Count++;
        }
        #endregion
    }
    public Node<T> Find(T target , Node<T> start, int depth = 1000)
    {
        if (start == null || depth <= 0) return null;//-> target no exista en la lsita doblemente enlazada

        if(start.Value.Equals(target))
        {
            return start;//-existe se encuentra y los retrno
        }


        return Find(target, start.Next, depth - 1);//->Analize el siguiente y reduzca el depth en 1
    }
    public void ReadForward(Node<T> value,int depth =1000)
    {
        if (value == null || depth <=0) return;

        Debug.Log(value.Value.ToString());

        if(value.Next != null)
            ReadForward(value.Next, depth - 1);
    }
    public void ReadBackward(Node<T> value, int depth = 1000)
    {
        if (value == null || depth <= 0) return;

        Debug.Log(value.Value.ToString());

        if (value.Prev != null)
            ReadBackward(value.Prev, depth - 1);
    }

    public void InsertAfter(T target, Node<T> value)
    {
        /*if (target == Tail)
        {
            value.SetPrev(Tail);
            value.SetNext(null);

            Tail.SetNext(value);

            Tail = value;
        }*/
        Node<T> temp = Find(target ,Head);
        if (temp == null)
        {
            Debug.LogError("NULLO");
            return;
        }
        if(temp.Next != null)
        {
            value.SetNext(temp.Next);
            value.SetPrev(temp);

            temp.Next.SetPrev(value);
            temp.SetNext(value);

        }
        else
        {
            value.SetPrev(temp);
            value.SetNext(null);

            temp.SetNext(value);

            Tail = value;
        }

    }
    public void Delete(T target)
    {
        if(Head.Value.Equals(target)) //-> que se busca eliminar la cabeza
        {
            Head = Head.Next;
            Head.Prev.SetNext(null);
            Head.SetPrev(null);

            Count--;
            return;
        }
        if (Tail.Value.Equals(target))//->Eliminacion al final
        {
            Tail = Tail.Prev;
            Tail.Next.SetPrev(null);
            Tail.SetNext(null);

            Count--;
            return;

        }
        //-Eliminacion en el medio
        Node<T> temp = Find(target, Head);
        if (temp == null) return;

        temp.Prev.SetNext(temp.Next);
        temp.Next.SetPrev(temp.Prev);

        temp.SetNext(null);
        temp.SetPrev(null);

        Count--;

    }

}
