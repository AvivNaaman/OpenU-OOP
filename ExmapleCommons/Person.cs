using System;
namespace ExmapleCommons
{
    /// <summary>
    /// This class describes a simple person.
    /// You cannot and should not inherit from this class.
    /// </summary>
    public sealed class Person
    {
        /// <summary>
        /// Person's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Person's last (sur) name
        /// </summary>
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"First Name: {FirstName} Last Name: {LastName}";
        }
    }
}

