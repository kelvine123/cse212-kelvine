
using System;
using System.Collections.Generic;

/// <summary>
/// A priority queue stores items with an associated priority.
///
/// Items are added to the back of the queue.
/// When removing an item, the item with the highest priority
/// is removed first.
///
/// If multiple items have the same priority, the item closest
/// to the front of the queue is removed first (FIFO).
/// </summary>
public class PriorityQueue
{
    // Stores the items and their priorities.
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Adds a new value and its priority to the back
    /// of the queue.
    /// </summary>
    /// <param name="value">The value to add.</param>
    /// <param name="priority">The priority of the value.</param>
    public void Enqueue(string value, int priority)
    {
        // Create a new priority item.
        var newNode = new PriorityItem(value, priority);

        // Add the new item to the back of the queue.
        _queue.Add(newNode);
    }

    /// <summary>
    /// Removes and returns the value with the highest priority.
    ///
    /// If multiple items have the same highest priority,
    /// the first item in the queue is selected.
    ///
    /// Throws InvalidOperationException if the queue is empty.
    /// </summary>
    /// <returns>The value of the item with the highest priority.</returns>
    public string Dequeue()
    {
        // Check whether the queue is empty.
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Start by assuming the first item has the highest priority.
        int highPriorityIndex = 0;

        // Search through the remaining items to find
        // the item with the highest priority.
        for (int index = 1; index < _queue.Count; index++)
        {
            // Use > instead of >= to preserve FIFO order
            // when two or more items have equal priority.
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Get the value of the highest priority item.
        string value = _queue[highPriorityIndex].Value;

        // Remove the selected item from the queue.
        _queue.RemoveAt(highPriorityIndex);

        // Return the removed item's value.
        return value;
    }

    // DO NOT MODIFY THIS METHOD.
    // The graders rely on this method to check your implementation.
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

/// <summary>
/// Represents an item stored in the priority queue.
/// Each item contains a value and its priority.
/// </summary>
internal class PriorityItem
{
    internal string Value { get; set; }

    internal int Priority { get; set; }

    /// <summary>
    /// Creates a new priority item.
    /// </summary>
    /// <param name="value">The item's value.</param>
    /// <param name="priority">The item's priority.</param>
    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THIS METHOD.
    // The graders rely on this method to check your implementation.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
