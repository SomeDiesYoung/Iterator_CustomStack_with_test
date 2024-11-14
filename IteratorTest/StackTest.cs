using IteratorPattern;

namespace IteratorTest;

public class StackTest
{
    [Fact]
    public void IterateOverStack()
    {
        //Arrange
        var testStack = new Stack<int>();
        testStack.Push(1);
        testStack.Push(2);
        testStack.Push(3);

        //act
        var result = new List<int>();
        foreach (var item in testStack)
        {
            result.Add(item);
        }

        //assert

        Assert.Equal(new List<int> { 3, 2, 1 }, result);
    }


    [Fact]
    public void Custom_Stack_Reaction_On_Empty_List() {
        var testStack = new Stack<int>();

        //act
        var result = new List<int>();
        foreach (var item in testStack)
        {
            result.Add(item);
        }

        //assert

        Assert.Equal([], result);
    }
}