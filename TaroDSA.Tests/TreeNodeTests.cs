using FluentAssertions;
using TaroDSA.Lib.DS;

namespace TaroDSA.Tests;
public class TreeNodeTests
{
    [Fact]
    public void Left_And_Right_Children_Are_Null_By_Default()
    {
        var treeNode = new TreeNode<int>(1);

        treeNode.Left.Should().BeNull();
        treeNode.Right.Should().BeNull();
    }

    [Fact]
    public void Can_Get_The_Node_Value()
    {
        var treeNode = new TreeNode<int>(1);

        treeNode.Value.Should().Be(1);
    }

    [Fact]
    public void Null_Values_Are_Ok()
    {
        var treeNode1 = new TreeNode<string>(null);
        treeNode1.Value.Should().BeNull();

        var treeNode2 = new TreeNode<int?>(null);
        treeNode2.Value.Should().BeNull();
    }
}
