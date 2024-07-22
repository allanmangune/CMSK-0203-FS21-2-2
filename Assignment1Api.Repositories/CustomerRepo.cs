using Assignment1Api.Entities;
using Assignment1Api.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1Api.Repositories
{
    /// <summary>
    /// Repository class for managing customer data.
    /// </summary>
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ILogger<CustomerRepo> _logger; // For logging
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepo"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="dbContext">The database context.</param>
        public CustomerRepo(ILogger<CustomerRepo> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets a customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>The customer with the specified ID, or null if not found.</returns>
        public Customer? GetCustomerById(int id)
        {
            try
            {
                return _dbContext.Customers.Find(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting customer with ID {id}.", id);
                throw;
            }
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _dbContext.Customers.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all customers.");
                throw;
            }
        }

        /// <summary>
        /// Modifies a customer.
        /// </summary>
        /// <param name="modifiedCustomer">The modified customer object.</param>
        /// <returns>The modified customer object.</returns>
        public Customer ModifyCustomer(Customer modifiedCustomer)
        {
            try
            {
                var existingCustomer = _dbContext.Customers.Find(modifiedCustomer.Id);
                if (existingCustomer == null) return null;

                existingCustomer.FirstName = modifiedCustomer.FirstName;
                existingCustomer.LastName = modifiedCustomer.LastName;
                _dbContext.SaveChanges();
                return modifiedCustomer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while modifying customer with ID {id}.", modifiedCustomer.Id);
                throw;
            }
        }

        /// <summary>
        /// Inserts a new customer.
        /// </summary>
        /// <param name="newCustomer">The new customer object.</param>
        /// <returns>The inserted customer object.</returns>
        public Customer InsertCustomer(Customer newCustomer)
        {
            try
            {
                _dbContext.Customers.Add(newCustomer);
                _dbContext.SaveChanges();
                return newCustomer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while inserting a new customer.");
                throw;
            }
        }

        /// <summary>
        /// Deletes a customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>True if the customer was deleted successfully, false otherwise.</returns>
        public bool DeleteCustomer(int id)
        {
            try
            {
                var customerToDelete = _dbContext.Customers.Find(id);
                if (customerToDelete == null) return false;

                _dbContext.Customers.Remove(customerToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting customer with ID {id}.", id);
                throw;
            }
        }
    }
}
