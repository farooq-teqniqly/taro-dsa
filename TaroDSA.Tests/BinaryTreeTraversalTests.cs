using FluentAssertions;
using TaroDSA.Lib.DS;

namespace TaroDSA.Tests;
public class BinaryTreeTraversalTests
{
    [Fact]
    public void BinaryTreeTraversalIterative_Returns_Expected_Results()
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

        var result = BinaryTreeTraversals.DepthFirstIterative(a);

        result.Select(node => node.Value)
            .ToArray()
            .SequenceEqual(['a', 'b', 'd', 'e', 'c', 'f'])
            .Should().BeTrue();
    }

    [Fact]
    public void BinaryTreeTraversalRecursive_Returns_Expected_Results()
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

        var result = BinaryTreeTraversals.DepthFirstRecursive(a);

        result.Select(node => node.Value)
            .ToArray()
            .SequenceEqual(['a', 'b', 'd', 'e', 'c', 'f'])
            .Should().BeTrue();
    }
}
