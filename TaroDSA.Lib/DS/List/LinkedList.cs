namespace TaroDSA.Lib.DS.List;

public class LinkedList<T>
{
    public enum ExecutionMode
    {
        Iterative = 0,
        Recursive
    }

    public static void Traverse(Node<T> head, Action<Node<T>> visitAction, ExecutionMode executionMode)
    {
        if (executionMode == ExecutionMode.Iterative)
        {
            var current = head;

            while (current != null)
            {
                visitAction(current);
                current = current.Next;
            }
        }
        else
        {
            TraverseRecursive(head, visitAction);
        }
    }

    private static void TraverseRecursive(Node<T>? current, Action<Node<T>> visitAction)
    {
        if (current == null)
        {
            return;
        }

        visitAction(current);
        TraverseRecursive(current.Next, visitAction);
    }
}
