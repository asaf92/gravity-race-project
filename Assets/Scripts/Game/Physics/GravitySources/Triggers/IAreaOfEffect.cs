using System.Collections.Generic;

/// <summary>
/// This interface is used by the AOE components to hold a collection of type <see cref="T"/>
/// </summary>
/// <typeparam name="T">The type that is collected</typeparam>
public interface IAreaOfEffect<T>
{
    /// <summary>
    /// An enumerable of all the objects of type <see cref="T"/> in the AOE
    /// </summary>
    IEnumerable<T> ObjectsInTrigger { get; }
}