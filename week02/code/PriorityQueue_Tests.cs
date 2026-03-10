using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:
    // Expected Result:
    // Defect(s) Found:
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 3);
        priorityQueue.Enqueue("Item3", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item3", result);
    }

    [TestMethod]
    // Scenario:
    // Expected Result:
    // Defect(s) Found:
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("First", result);
    }

    // Add more test cases as needed below.
    [TestMethod]
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}
