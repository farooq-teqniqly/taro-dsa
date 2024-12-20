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
        return DepthFirstRecursiveLocal(root);

        IEnumerable<TreeNode<TValue>> DepthFirstRecursiveLocal<TValue>(TreeNode<TValue>? currentRoot)
        {
            if (currentRoot == null)
            {
                yield break;
            }

            yield return currentRoot;

            foreach (var node in DepthFirstRecursiveLocal(currentRoot.Left))
            {
                yield return node;
            }

            foreach (var node in DepthFirstRecursiveLocal(currentRoot.Right))
            {
                yield return node;
            }

        }
    }

    /// <summary>
    /// Performs an iterative breadth-first traversal on a binary tree starting from the specified root node.
    /// Time complexity: O(n) where `n` is the number of nodes.
    /// Space complexity: O(n) for the queue.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value stored in the tree nodes.
    /// </typeparam>
    /// <param name="root">
    /// The root node of the binary tree to traverse. Must not be <c>null</c>.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> of <see cref="TreeNode{T}"/> objects representing the nodes
    /// of the binary tree in breadth-first order.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="root"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method uses a queue to traverse the binary tree iteratively, visiting all nodes at the current
    /// depth level before moving to the next depth level.
    /// </remarks>
    public static IEnumerable<TreeNode<T>> BreadthFirst<T>(TreeNode<T> root)
    {
        ArgumentNullException.ThrowIfNull(root);

        var queue = new Queue<TreeNode<T>>([root]);

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();

            yield return current;

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }
    }

    /// <summary>
    /// Calculates the sum of all node values in a binary tree starting from the specified root node.
    /// </summary>
    /// <param name="root">
    /// The root node of the binary tree. Must not be <c>null</c>.
    /// </param>
    /// <returns>
    /// The sum of all node values in the binary tree.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="root"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method performs a breadth-first traversal of the binary tree to compute the sum of all node values.
    /// It leverages the <see cref="BreadthFirst{T}"/> method for traversal.
    /// </remarks>
    public static int TreeSum(TreeNode<int> root)
    {
        return BreadthFirst(root).Sum(node => node.Value);
    }

    /// <summary>
    /// Determines whether a binary tree includes a node with the specified value.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value stored in the tree nodes.
    /// </typeparam>
    /// <param name="root">
    /// The root node of the binary tree to search. Must not be <c>null</c>.
    /// </param>
    /// <param name="value">
    /// The value to search for in the binary tree.
    /// </param>
    /// <returns>
    /// The first <see cref="TreeNode{T}"/> containing the specified value, or <c>null</c> if no such node exists.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="root"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method performs a breadth-first traversal of the binary tree to locate the first node
    /// whose value matches the specified <paramref name="value"/>.
    /// </remarks>
    public static TreeNode<T>? TreeIncludes<T>(TreeNode<T> root, T value)
    {
        return BreadthFirst(root).FirstOrDefault(node => node.Value != null && node.Value.Equals(value));
    }

    /// <summary>
    /// Finds the node with the minimum value in a binary tree using a breadth-first traversal.
    /// </summary>
    /// <param name="root">
    /// The root node of the binary tree. Must not be <c>null</c>.
    /// </param>
    /// <returns>
    /// The <see cref="TreeNode{T}"/> containing the minimum value in the binary tree.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="root"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method traverses the binary tree in breadth-first order and compares the values of the nodes
    /// to determine the node with the smallest value.
    /// </remarks>
    public static TreeNode<int> TreeMin(TreeNode<int> root)
    {
        return BreadthFirst(root).Aggregate((minNode, currentNode) =>
            currentNode.Value < minNode.Value ? currentNode : minNode);
    }

    /// <summary>
    /// Finds the node with the maximum value in a binary tree starting from the specified root node.
    /// </summary>
    /// <param name="root">
    /// The root node of the binary tree to search. Must not be <c>null</c>.
    /// </param>
    /// <returns>
    /// The <see cref="TreeNode{T}"/> containing the maximum value in the binary tree.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="root"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method performs a breadth-first traversal of the binary tree to find the node with the maximum value.
    /// The traversal ensures that all nodes are visited, and the maximum value is determined by comparing the
    /// <see cref="TreeNode{T}.Value"/> of each node.
    /// </remarks>
    public static TreeNode<int> TreeMax(TreeNode<int> root)
    {
        return BreadthFirst(root).Aggregate((maxNode, currentNode) =>
            currentNode.Value > maxNode.Value ? currentNode : maxNode);
    }

    /// <summary>
    /// Specifies the type of sum to compute in a binary tree.
    /// </summary>
    /// <remarks>
    /// This enumeration is used to indicate whether to compute the maximum or minimum path sum in a binary tree.
    /// </remarks>
    /// <summary>
    /// Indicates that the maximum path sum should be computed.
    /// </summary>
    /// <summary>
    /// Indicates that the minimum path sum should be computed.
    /// </summary>
    public enum SumType
    {
        Max,
        Min
    }

    /// <summary>
    /// Computes the maximum or minimum path sum in a binary tree, depending on the specified <paramref name="sumType"/>.
    /// Time complexity: O(n) where `n` is the number of nodes.
    /// Space complexity: O(n) because of the recursion.
    /// </summary>
    /// <param name="root">
    /// The root node of the binary tree. If <c>null</c>, the method returns <see cref="int.MinValue"/> for <see cref="SumType.Max"/> 
    /// or <see cref="int.MaxValue"/> for <see cref="SumType.Min"/>.
    /// </param>
    /// <param name="sumType">
    /// Specifies whether to compute the maximum or minimum path sum. Defaults to <see cref="SumType.Max"/>.
    /// </param>
    /// <returns>
    /// The computed path sum. If the tree is empty, returns <see cref="int.MinValue"/> for <see cref="SumType.Max"/> 
    /// or <see cref="int.MaxValue"/> for <see cref="SumType.Min"/>.
    /// </returns>
    /// <remarks>
    /// A path is defined as any sequence of nodes from the root to a leaf. The method recursively computes the path sums 
    /// for the left and right subtrees and combines them with the value of the current node.
    /// </remarks>
    /// <example>
    /// <code>
    /// var root = new TreeNode<int>(3)
    /// {
    ///     Left = new TreeNode<int>(11)
    ///     {
    ///         Left = new TreeNode<int>(4),
    ///         Right = new TreeNode<int>(-2)
    ///     },
    ///     Right = new TreeNode<int>(4)
    ///     {
    ///         Right = new TreeNode<int>(1)
    ///     }
    /// };
    /// 
    /// var maxSum = BinaryTreeTraversals.PathSum(root); // Returns 18
    /// var minSum = BinaryTreeTraversals.PathSum(root, BinaryTreeTraversals.SumType.Min); // Returns 8
    /// </code>
    /// </example>
    public static int PathSum(TreeNode<int>? root, SumType sumType = SumType.Max)
    {
        if (root == null)
        {
            return sumType == SumType.Max ? int.MinValue : int.MaxValue;
        }

        if (root.Left == null && root.Right == null)
        {
            return root.Value;
        }

        var leftSum = PathSum(root.Left);
        var rightSum = PathSum(root.Right);

        if (sumType == SumType.Max)
        {
            return root.Value + Max(leftSum, rightSum);
        }

        return root.Value + Min(leftSum, rightSum);

        int Max(int x, int y)
        {
            return x > y ? x : y;
        }

        int Min(int x, int y)
        {
            return x < y ? x : y;
        }
    }
}
