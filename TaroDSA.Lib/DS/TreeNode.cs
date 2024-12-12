namespace TaroDSA.Lib.DS;
/// <summary>
/// Represents a node in a binary tree structure.
/// </summary>
/// <typeparam name="T">
/// The type of the value stored in the tree node.
/// </typeparam>
public class TreeNode<T>
{
    /// <summary>
    /// Gets or sets the left child node of the current tree node.
    /// </summary>
    /// <value>
    /// The left child node, or <c>null</c> if no left child exists.
    /// </value>
    public TreeNode<T>? Left { get; set; }
    /// <summary>
    /// Gets or sets the right child node of the current tree node.
    /// </summary>
    /// <value>
    /// The right child node of type <see cref="TreeNode{T}"/> or <c>null</c> if no right child exists.
    /// </value>
    public TreeNode<T>? Right { get; set; }

    /// <summary>
    /// Gets the value stored in the tree node.
    /// </summary>
    /// <value>
    /// The value of type <typeparamref name="T"/> stored in the node. 
    /// This value can be <c>null</c> if the node was initialized with a null value.
    /// </value>
    public T? Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TreeNode{T}"/> class with the specified value.
    /// </summary>
    /// <param name="value">
    /// The value to store in the tree node. Can be <c>null</c>.
    /// </param>
    public TreeNode(T? value)
    {
        Value = value;
    }
}
