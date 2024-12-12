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

    [Fact]
    public void TreeSum_Returns_Expected_Result()
    {
        var a = new TreeNode<int>(3);
        var b = new TreeNode<int>(11);
        var c = new TreeNode<int>(4);
        var d = new TreeNode<int>(4);
        var e = new TreeNode<int>(-2);
        var f = new TreeNode<int>(1);

        a.Left = b;
        a.Right = c;
        b.Left = d;
        b.Right = e;
        c.Right = f;

        var result = BinaryTreeTraversals.TreeSum(a);

        result.Should().Be(21);
    }

    [Fact]
    public void TreeIncludes_Returns_Expected_Result()
    {
        var result = BinaryTreeTraversals.TreeIncludes(_root, 'e');
        result.Should().NotBe(null);
        result!.Value.Should().Be('e');

        result = BinaryTreeTraversals.TreeIncludes(_root, 'z');
        result.Should().BeNull();
    }

    [Fact]
    public void TreeMin_Returns_Expected_Result()
    {
        var a = new TreeNode<int>(3);
        var b = new TreeNode<int>(11);
        var c = new TreeNode<int>(4);
        var d = new TreeNode<int>(4);
        var e = new TreeNode<int>(-2);
        var f = new TreeNode<int>(1);

        a.Left = b;
        a.Right = c;
        b.Left = d;
        b.Right = e;
        c.Right = f;

        var result = BinaryTreeTraversals.TreeMin(a);

        result.Value.Should().Be(-2);
    }

    [Fact]
    public void TreeMax_Returns_Expected_Result()
    {
        var a = new TreeNode<int>(3);
        var b = new TreeNode<int>(11);
        var c = new TreeNode<int>(4);
        var d = new TreeNode<int>(4);
        var e = new TreeNode<int>(-2);
        var f = new TreeNode<int>(1);

        a.Left = b;
        a.Right = c;
        b.Left = d;
        b.Right = e;
        c.Right = f;

        var result = BinaryTreeTraversals.TreeMax(a);

        result.Value.Should().Be(11);
    }
}
