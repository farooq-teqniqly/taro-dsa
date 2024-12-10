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

    [Fact]
    public void Can_Reverse_Linked_List()
    {
        var f = new Node<char>('f');
        var i = new Node<char>('i');
        var s = new Node<char>('s');
        var h = new Node<char>('h');

        f.Next = i;
        i.Next = s;
        s.Next = h;

        var newHead = Lib.DS.LinkedList<char>.Reverse(f);
        newHead.Value.Should().Be('h');

        var sb = new StringBuilder(4);

        void Visit(Node<char> node)
        {
            sb.Append(node.Value);
        }

        Lib.DS.LinkedList<char>.Traverse(newHead, Visit, Lib.DS.LinkedList<char>.ExecutionMode.Iterative);

        sb.ToString().Should().Be("hsif");
    }

    [Fact]
    public void Can_Reverse_One_Node_Linked_List()
    {
        var f = new Node<char>('f');

        var newHead = Lib.DS.LinkedList<char>.Reverse(f);

        newHead.Value.Should().Be('f');
    }

    [Fact]
    public void Reverse_Throws_When_Head_Is_Null()
    {
        var act = () => Lib.DS.LinkedList<char>.Reverse(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Can_Zipper_Two_Lists_When_First_Is_Longer_Than_Second()
    {
        var f = new Node<char>('f');
        var i = new Node<char>('i');
        var s = new Node<char>('s');
        var h = new Node<char>('h');

        f.Next = i;
        i.Next = s;
        s.Next = h;

        var b = new Node<char>('b');
        var u = new Node<char>('u');
        

        b.Next = u;
        
        var head = Lib.DS.LinkedList<char>.Zipper(f, b);

        var sb = new StringBuilder(6);

        void Visit(Node<char> node)
        {
            sb.Append(node.Value);
        }

        Lib.DS.LinkedList<char>.Traverse(head, Visit, Lib.DS.LinkedList<char>.ExecutionMode.Iterative);

        sb.ToString().Should().Be("fbiush");
    }

    [Fact]
    public void Can_Zipper_Two_Lists_When_Second_Is_Longer_Than_First()
    {
        var b = new Node<char>('b');
        var u = new Node<char>('u');
        b.Next = u;

        var f = new Node<char>('f');
        var i = new Node<char>('i');
        var s = new Node<char>('s');
        var h = new Node<char>('h');

        f.Next = i;
        i.Next = s;
        s.Next = h;

        var head = Lib.DS.LinkedList<char>.Zipper(b, f);

        var sb = new StringBuilder(6);

        void Visit(Node<char> node)
        {
            sb.Append(node.Value);
        }

        Lib.DS.LinkedList<char>.Traverse(head, Visit, Lib.DS.LinkedList<char>.ExecutionMode.Iterative);

        sb.ToString().Should().Be("bfuish");
    }

    [Fact]
    public void Can_Zipper_Two_Single_Node_Lists()
    {
        var b = new Node<char>('b');

        var f = new Node<char>('f');

        var head = Lib.DS.LinkedList<char>.Zipper(b, f);

        var sb = new StringBuilder(2);

        void Visit(Node<char> node)
        {
            sb.Append(node.Value);
        }

        Lib.DS.LinkedList<char>.Traverse(head, Visit, Lib.DS.LinkedList<char>.ExecutionMode.Iterative);

        sb.ToString().Should().Be("bf");
    }

    [Fact]
    public void Zipper_When_Lists_Null_Throws()
    {
        var act1 = () => Lib.DS.LinkedList<char>.Zipper(null!, new Node<char>('a'));
        act1.Should().Throw<ArgumentNullException>();

        var act2 = () => Lib.DS.LinkedList<char>.Zipper(new Node<char>('a'), null!);
        act2.Should().Throw<ArgumentNullException>();

    }
}
