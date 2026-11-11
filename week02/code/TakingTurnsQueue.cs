
using System;

/// <summary>
/// This class maintains a circular queue of people.
///
/// People are added to the back of the queue using AddPerson().
/// When GetNextPerson() is called, the person at the front is removed
/// and returned.
///
/// If a person still has turns remaining, they are added back to the
/// end of the queue.
///
/// A turns value of zero or less means the person has infinite turns
/// and will remain in the queue forever.
/// </summary>
public class TakingTurnsQueue
{
    // Stores all people currently waiting in the queue.
    private readonly PersonQueue _people = new();

    /// <summary>
    /// Gets the number of people currently in the queue.
    /// </summary>
    public int Length => _people.Length;

    /// <summary>
    /// Adds a new person to the back of the queue.
    /// </summary>
    /// <param name="name">The name of the person.</param>
    /// <param name="turns">The number of turns assigned to the person.
    /// Zero or negative values represent infinite turns.</param>
    public void AddPerson(string name, int turns)
    {
        // Create a new person with the specified name and turns.
        var person = new Person(name, turns);

        // Add the person to the back of the queue.
        _people.Enqueue(person);
    }

    /// <summary>
    /// Gets the next person in the queue and returns them.
    ///
    /// If the person has finite turns, their remaining turns are
    /// decreased by one.
    ///
    /// If they still have turns remaining, they are added back
    /// to the end of the queue.
    ///
    /// If their turns are zero or negative, they have infinite
    /// turns and are always added back to the queue.
    ///
    /// Throws an InvalidOperationException if the queue is empty.
    /// </summary>
    /// <returns>The next person in the queue.</returns>
    public Person GetNextPerson()
    {
        // Check whether the queue is empty before attempting
        // to remove anyone.
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Remove the person at the front of the queue.
        Person person = _people.Dequeue();

        // A turns value of zero or less means infinite turns.
        // Such a person must always be added back to the queue.
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        else
        {
            // Reduce the person's remaining turns by one.
            person.Turns--;

            // Add the person back only if they still have
            // at least one turn remaining.
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        // Return the person whose turn was just processed.
        return person;
    }

    /// <summary>
    /// Returns a string representation of the queue.
    /// </summary>
    /// <returns>The queue contents as a string.</returns>
    public override string ToString()
    {
        return _people.ToString();
    }
}
