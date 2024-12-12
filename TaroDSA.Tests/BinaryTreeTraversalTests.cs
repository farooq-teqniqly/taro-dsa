using FluentAssertions;
using TaroDSA.Lib.DS;

namespace TaroDSA.Tests;
public class BinaryTreeTraversalTests
{
    private readonly TreeNode<char> _root;

    public BinaryTreeTraversalTests()
    {
        var a = new TreeNode<char>('a');
        var b = new TreeNode<char>('b');
        var c = new TreeNode<char>('c');
        var d = new TreeNode<char>('d');
        var e = new TreeNode<char>('e');
        var f = new TreeNode<char>('f');

        a.Left = b;
        a.Right = c;
        b.Left = d;
        b.Right = e;
        c.Right = f;

        _root = a;
    }
    [Fact]
    public void DepthFirstIterative_Returns_Expected_Results()
    {
        var result = BinaryTreeTraversals.DepthFirstIterative(_root);

        result.Select(node => node.Value)
            .ToArray()
            .SequenceEqual(['a', 'b', 'd', 'e', 'c', 'f'])
            .Should().BeTrue();
    }

    [Fact]
    public void DepthFirstRecursive_Returns_Expected_Results()
    {
        var result = BinaryTreeTraversals.DepthFirstRecursive(_root);

        result.Select(node => node.Value)
            .ToArray()
            .SequenceEqual(['a', 'b', 'd', 'e', 'c', 'f'])
            .Should().BeTrue();
    }

    [Fact]
    public void BreadthFirstIterative_Returns_Expected_Results()
    {
        var result = BinaryTreeTraversals.BreadthFirst(_root);

        result.Select(node => node.Value)
            .ToArray()
            .SequenceEqual(['a', 'b', 'c', 'd', 'e', 'f'])
            .Should().BeTrue();
    }
}
