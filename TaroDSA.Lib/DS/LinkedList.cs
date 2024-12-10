using System.Diagnostics;

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

    /// <summary>
    /// Finds the first node in the linked list that contains the specified value.
    /// </summary>
    /// <param name="head">The head node of the linked list.</param>
    /// <param name="value">The value to search for in the linked list.</param>
    /// <returns>The first node that contains the specified value, or <c>null</c> if no such node is found.</returns>
    public static Node<T>? FindFirst(Node<T> head, T value)
    {
        var current = head;

        while (current != null)
        {
            if (current.Value != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
            }

            current = current.Next;
        }

        return null;
    }

    /// <summary>
    /// Gets the node at the specified index in the linked list.
    /// </summary>
    /// <param name="head">The head node of the linked list.</param>
    /// <param name="index">The zero-based index of the node to retrieve.</param>
    /// <returns>The node at the specified index.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the head node is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is negative.</exception>
    /// <exception cref="IndexOutOfRangeException">Thrown when the index is out of the range of the linked list.</exception>
    public static Node<T> GetAtIndex(Node<T> head, int index)
    {
        ArgumentNullException.ThrowIfNull(head);
        ArgumentOutOfRangeException.ThrowIfNegative(index);

        var current = head;
        var currentIndex = index;

        while (current != null)
        {
            if (currentIndex == 0)
            {
                return current;
            }

            current = current.Next;
            currentIndex--;
        }

        throw new IndexOutOfRangeException();
    }

    /// <summary>
    /// Reverses the linked list starting from the given head node.
    /// </summary>
    /// <param name="head">The head node of the linked list to reverse.</param>
    /// <returns>The new head node of the reversed linked list.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the head node is null.</exception>
    public static Node<T> Reverse(Node<T> head)
    {
        ArgumentNullException.ThrowIfNull(head);

        Node<T>? previous = null;
        var current = head;
        var next = current.Next;

        while (current != null)
        {
            current.Next = previous;
            previous = current;
            current = next;
            next = current?.Next;
        }

        return previous!;
    }
}
