using Assignment1Api.Entities;
using System.Collections.Generic;

namespace Assignment1Api.Interfaces
{
    /// <summary>
    /// Represents a repository for managing customers.
    /// </summary>
    public interface ICustomerRepo
    {
        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        /// <returns>A list of customers.</returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// Modifies an existing customer.
        /// </summary>
        /// <param name="modifiedCustomer">The modified customer object.</param>
        /// <returns>The modified customer object.</returns>
        Customer ModifyCustomer(Customer modifiedCustomer);

        /// <summary>
        /// Retrieves a customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>The customer object if found, otherwise null.</returns>
        Customer? GetCustomerById(int id);

        /// <summary>
        /// Inserts a new customer.
        /// </summary>
        /// <param name="newCustomer">The new customer object.</param>
        /// <returns>The inserted customer object.</returns>
        Customer InsertCustomer(Customer newCustomer);

        /// <summary>
        /// Deletes a customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>True if the customer was deleted successfully, otherwise false.</returns>
        bool DeleteCustomer(int id);
    }
}
