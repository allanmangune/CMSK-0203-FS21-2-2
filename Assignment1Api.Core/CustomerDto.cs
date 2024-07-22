namespace Assignment1Api.Core
{
    /// <summary>
    /// Represents a customer data transfer object.
    /// </summary>
    public class CustomerDto 
    {
        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        public string LastName { get; set; }
    }
}

