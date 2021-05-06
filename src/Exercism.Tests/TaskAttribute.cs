using System;

namespace Exercism.Tests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class TaskAttribute : Attribute
    {
        public int Number { get; }

        public TaskAttribute(int number)
        {
            if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number), number, "Number must be greater than zero");

            Number = number;
        }
    }
}
