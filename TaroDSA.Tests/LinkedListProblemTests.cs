using System.Text;
using FluentAssertions;
using TaroDSA.Lib.DS.List;

namespace TaroDSA.Tests;
public class LinkedListProblemTests
{
    [Theory]
    [InlineData(Lib.DS.List.LinkedList<char>.ExecutionMode.Iterative)]
    [InlineData(Lib.DS.List.LinkedList<char>.ExecutionMode.Recursive)]
    public void Can_Traverse_Linked_List(Lib.DS.List.LinkedList<char>.ExecutionMode mode)
    {
        var f = new Node<char>('f');
        var i = new Node<char>('i');
        var s = new Node<char>('s');
        var h = new Node<char>('h');

        f.Next = i;
        i.Next = s;
        s.Next = h;

        var sb = new StringBuilder(4);

        Lib.DS.List.LinkedList<char>.Traverse(f, Visit, mode);

        sb.ToString().Should().Be("fish");
        return;

        void Visit(Node<char> node)
        {
            sb.Append(node.Value);
        }
    }
}