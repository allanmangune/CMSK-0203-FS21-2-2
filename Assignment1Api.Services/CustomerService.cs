using Assignment1Api.Entities;
using Assignment1Api.Interfaces;
using Assignment1Api.Core; 
using AutoMapper;
using Microsoft.Extensions.Logging;

/// <summary>
/// Represents a service for managing customers.
/// </summary>
public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly ILogger<CustomerService> _logger;
    private readonly ICustomerRepo _customerRepository;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerService"/> class.
    /// </summary>
    /// <param name="customerRepository">The customer repository.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="mapper">The mapper.</param>
    public CustomerService(IMapper mapper, ILogger<CustomerService> logger, ICustomerRepo customerRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _customerRepository = customerRepository;
    }

    /// <summary>
    /// Gets all customers.
    /// </summary>
    /// <returns>A list of <see cref="CustomerDto"/>.</returns>
    public List<CustomerDto> GetAllCustomers()
    {
        try
        {
            var existingCustomers = _customerRepository.GetAllCustomers();
            return _mapper.Map<List<CustomerDto>>(existingCustomers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while loading existing customers.");
            throw; 
        }
    }

    /// <summary>
    /// Gets a customer by ID.
    /// </summary>
    /// <param name="id">The ID of the customer.</param>
    /// <returns>The <see cref="CustomerDto"/> with the specified ID, or null if not found.</returns>
    public CustomerDto? GetCustomerById(int id)
    {
        try
        {
            var existingCustomer = _customerRepository.GetCustomerById(id);
            return existingCustomer != null ? _mapper.Map<CustomerDto>(existingCustomer) : null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while retrieving customer with ID {id}.", id);
            throw; 
        }
    }

    /// <summary>
    /// Updates an existing customer.
    /// </summary>
    /// <param name="customerDto">The <see cref="CustomerDto"/> representing the customer to update.</param>
    /// <returns>The <see cref="CustomerDto"/> of the updated customer, or null if not found.</returns>
    public CustomerDto EditCustomer(CustomerDto customerDto)
    {
        try
        {
            var customer = _mapper.Map<Customer>(customerDto);
            var modifiedCustomer = _customerRepository.ModifyCustomer(customer);
            return modifiedCustomer != null ? _mapper.Map<CustomerDto>(modifiedCustomer) : null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while editing customer with ID {id}.", customerDto.Id);
            throw;
        }
    }

    /// <summary>
    /// Adds a new customer.
    /// </summary>
    /// <param name="customerDto">The <see cref="CustomerDto"/> representing the customer to add.</param>
    /// <returns>The <see cref="CustomerDto"/> of the added customer.</returns>
    public CustomerDto CreateCustomer(CustomerDto customerDto)
    {
        try
        {
            var newCustomer = _mapper.Map<Customer>(customerDto);
            var insertedCustomer = _customerRepository.InsertCustomer(newCustomer);
            return _mapper.Map<CustomerDto>(insertedCustomer);
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
            return _customerRepository.DeleteCustomer(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting customer with ID {id}.", id);
            throw;
        }
    }
}
