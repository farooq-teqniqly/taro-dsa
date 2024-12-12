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
    /// Performs an iterative depth-first traversal on a binary tree starting from the specified root node.
    /// Time complexity: O(n) where `n` is the number of nodes.
    /// Space complexity: O(n) for the stack.
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
    /// <remarks>
    /// This method uses a stack to traverse the binary tree iteratively, visiting the left subtree
    /// before the right subtree for each node.
    /// </remarks>
    public static IEnumerable<TreeNode<T>> DepthFirstIterative<T>(TreeNode<T> root)
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

    /// <summary>
    /// Performs a recursive depth-first traversal on a binary tree starting from the specified root node.
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
    /// <remarks>
    /// This method uses recursion to traverse the binary tree, visiting the left subtree
    /// before the right subtree for each node.
    /// 
    /// Time complexity: O(n), where <c>n</c> is the number of nodes in the binary tree.
    /// Space complexity: O(h), where <c>h</c> is the height of the binary tree, due to the recursive call stack.
    /// </remarks>
    public static IEnumerable<TreeNode<T>> DepthFirstRecursive<T>(TreeNode<T> root)
    {
        ArgumentNullException.ThrowIfNull(root);
        return DepthFirstRecursiveImpl(root);

        IEnumerable<TreeNode<TValue>> DepthFirstRecursiveImpl<TValue>(TreeNode<TValue>? currentRoot)
        {
            if (currentRoot == null)
            {
                yield break;
            }

            yield return currentRoot;

            foreach (var node in DepthFirstRecursiveImpl(currentRoot.Left))
            {
                yield return node;
            }

            foreach (var node in DepthFirstRecursiveImpl(currentRoot.Right))
            {
                yield return node;
            }

        }
    }
}
