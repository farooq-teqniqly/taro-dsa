using System.Text;
using FluentAssertions;
using TaroDSA.Lib.DS;

namespace TaroDSA.Tests;
public class LinkedListProblemTests
{
    [Theory]
    [InlineData(Lib.DS.LinkedList<char>.ExecutionMode.Iterative)]
    [InlineData(Lib.DS.LinkedList<char>.ExecutionMode.Recursive)]
    public void Can_Traverse_Linked_List(Lib.DS.LinkedList<char>.ExecutionMode mode)
    {
        var f = new Node<char>('f');
        var i = new Node<char>('i');
        var s = new Node<char>('s');
        var h = new Node<char>('h');

        f.Next = i;
        i.Next = s;
        s.Next = h;

        var sb = new StringBuilder(4);

        Lib.DS.LinkedList<char>.Traverse(f, Visit, mode);

        sb.ToString().Should().Be("fish");
        return;

        void Visit(Node<char> node)
        {
            sb.Append(node.Value);
        }
    }

    [Theory]
    [InlineData(Lib.DS.LinkedList<int>.ExecutionMode.Iterative)]
    [InlineData(Lib.DS.LinkedList<int>.ExecutionMode.Recursive)]
    public void Can_Sum_The_Nodes_In_List(Lib.DS.LinkedList<int>.ExecutionMode mode)
    {
        var first = new Node<int>(2);
        var second = new Node<int>(8);
        var third = new Node<int>(3);
        var fourth = new Node<int>(7);

        first.Next = second;
        second.Next = third;
        third.Next = fourth;

        var expectedSum = 20;
        var actualSum = 0;

        Lib.DS.LinkedList<int>.Traverse(first, Visit, mode);

        actualSum.Should().Be(expectedSum);
        return;

        void Visit(Node<int> node)
        {
            actualSum += node.Value;
        }
    }

    [Theory]
    [InlineData(false, 3)]
    [InlineData(true, 0)]
    public void Can_Find_A_Node_In_List(bool nodeIsNull, int expectedValue)
    {
        var first = new Node<int>(2);
        var second = new Node<int>(8);
        var third = new Node<int>(3);
        var fourth = new Node<int>(7);

        first.Next = second;
        second.Next = third;
        third.Next = fourth;

        var result = Lib.DS.LinkedList<int>.FindFirst(first, expectedValue);

        if (nodeIsNull)
        {
            result.Should().BeNull();
        }
        else
        {
            result.Should().NotBeNull();
            result!.Value.Should().Be(expectedValue);
        }

    }

    [Theory]
    [InlineData(0, 2)]
    [InlineData(1, 8)]
    [InlineData(2, 3)]
    [InlineData(3, 7)]
    public void GetAtIndex_Returns_Expected_Result(int index, int expectedValue)
    {
        var first = new Node<int>(2);
        var second = new Node<int>(8);
        var third = new Node<int>(3);
        var fourth = new Node<int>(7);

        first.Next = second;
        second.Next = third;
        third.Next = fourth;

        var result = Lib.DS.LinkedList<int>.GetAtIndex(first, index);

        result.Value.Should().Be(expectedValue);
    }

    [Fact]
    public void GetAtIndex_When_Walked_Past_End_Of_List_Throws()
    {
        var first = new Node<int>(2);
        var second = new Node<int>(8);
        var third = new Node<int>(3);
        var fourth = new Node<int>(7);

        first.Next = second;
        second.Next = third;
        third.Next = fourth;

        var act = () => Lib.DS.LinkedList<int>.GetAtIndex(first, 10);

        act.Should().Throw<IndexOutOfRangeException>();
    }

    [Fact]
    public void GetAtIndex_When_Index_Negative_Throws()
    {
        var first = new Node<int>(2);
        var second = new Node<int>(8);
        var third = new Node<int>(3);
        var fourth = new Node<int>(7);

        first.Next = second;
        second.Next = third;
        third.Next = fourth;

        var act = () => Lib.DS.LinkedList<int>.GetAtIndex(first, -1);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GetAtIndex_When_Head_Is_Null_Throws()
    {
        var act = () => Lib.DS.LinkedList<int>.GetAtIndex(null!, 0);

        act.Should().Throw<ArgumentNullException>();
    }
}
