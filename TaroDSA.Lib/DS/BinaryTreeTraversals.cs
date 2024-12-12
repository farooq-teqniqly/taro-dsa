namespace TaroDSA.Lib.DS;
/// <summary>
/// Provides traversal algorithms for binary trees.
/// </summary>
/// <remarks>
/// This class contains static methods for traversing binary trees in various orders.
/// It is designed to work with trees represented using the <see cref="TreeNode{T}"/> class.
/// </remarks>
public class BinaryTreeTraversals
{
    /// <summary>
    /// Performs a depth-first traversal on a binary tree starting from the specified root node.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value stored in the tree nodes.
    /// </typeparam>
    /// <param name="root">
    /// The root node of the binary tree to traverse. Must not be <c>null</c>.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of <see cref="TreeNode{T}"/> objects representing the nodes
    /// of the binary tree in depth-first order.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="root"/> is <c>null</c>.
    /// </exception>
    public static IEnumerable<TreeNode<T>> DepthFirst<T>(TreeNode<T> root)
    {
        ArgumentNullException.ThrowIfNull(root);

        var stack = new Stack<TreeNode<T>>([root]);

        while (stack.Count != 0)
        {
            var current = stack.Pop();

            yield return current;

            if (current.Right != null)
            {
                stack.Push(current.Right);
            }

            if (current.Left != null)
            {
                stack.Push(current.Left);
            }
        }

    }
}
