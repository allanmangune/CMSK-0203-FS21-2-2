using Assignment1Api.Entities;
using System.Collections.Generic;
using Assignment1Api.Core;

namespace Assignment1Api.Interfaces
{
    /// <summary>
    /// Represents a service for managing customers.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customerDto">The customer data transfer object.</param>
        /// <returns>The created customer data transfer object.</returns>
        CustomerDto CreateCustomer(CustomerDto customerDto);

        /// <summary>
        /// Edits an existing customer.
        /// </summary>
        /// <param name="customerDto">The customer data transfer object.</param>
        /// <returns>The edited customer data transfer object.</returns>
        CustomerDto EditCustomer(CustomerDto customerDto);

        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        /// <returns>A list of customer data transfer objects.</returns>
        List<CustomerDto> GetAllCustomers();

        /// <summary>
        /// Retrieves a customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>The customer data transfer object, or null if not found.</returns>
        CustomerDto? GetCustomerById(int id);

        /// <summary>
        /// Deletes a customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>True if the customer was successfully deleted, false otherwise.</returns>
        bool DeleteCustomer(int id);
    }
}
