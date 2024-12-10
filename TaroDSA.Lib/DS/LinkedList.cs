namespace TaroDSA.Lib.DS;
/// <summary>
/// Represents a node in a linked list.
/// </summary>
/// <typeparam name="T">The type of the value stored in the node.</typeparam>
public class Node<T>
{
    /// <summary>
    /// Gets the value stored in the node.
    /// </summary>
    public T Value { get; }

    /// <summary>
    /// Gets or sets the next node in the linked list.
    /// </summary>
    public Node<T>? Next { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Node{T}"/> class with the specified value.
    /// </summary>
    /// <param name="value">The value to store in the node.</param>
    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}

public class LinkedList<T>
{
    /// <summary>
    /// Specifies the mode of execution for traversing the linked list.
    /// </summary>
    public enum ExecutionMode
    {
        /// <summary>
        /// Traverse the linked list iteratively.
        /// </summary>
        Iterative = 0,

        /// <summary>
        /// Traverse the linked list recursively.
        /// </summary>
        Recursive
    }

    /// <summary>
    /// Traverses the linked list starting from the given head node and performs the specified action on each node.
    /// </summary>
    /// <param name="head">The head node of the linked list.</param>
    /// <param name="visitAction">The action to perform on each node.</param>
    /// <param name="executionMode">The mode of execution for traversing the linked list.</param>
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

    /// <summary>
    /// Recursively traverses the linked list starting from the given node and performs the specified action on each node.
    /// </summary>
    /// <param name="current">The current node in the linked list.</param>
    /// <param name="visitAction">The action to perform on each node.</param>
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
