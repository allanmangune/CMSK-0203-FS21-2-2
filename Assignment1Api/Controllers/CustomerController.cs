using Assignment1Api.Core; 
using Assignment1Api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a controller for managing customer data.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMapper _mapper; 
    private readonly ICustomerService _customerService;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerController"/> class.
    /// </summary>
    /// <param name="customerService">The customer service.</param>
    /// <param name="mapper">The mapper.</param>
    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _mapper = mapper;
        _customerService = customerService;
    }

    /// <summary>
    /// Gets all customers.
    /// </summary>
    /// <returns>An action result containing a collection of <see cref="CustomerDto"/>.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<CustomerDto>> GetAllCustomers()
    {
        return Ok(_customerService.GetAllCustomers());
    }

    /// <summary>
    /// Gets a customer by ID.
    /// </summary>
    /// <param name="id">The ID of the customer.</param>
    /// <returns>An action result containing the <see cref="CustomerDto"/> if found; otherwise, returns NotFound.</returns>
    [HttpGet("{id}")]
    public ActionResult<CustomerDto> GetCustomerById(int id)
    {
        var existingCustomer = _customerService.GetCustomerById(id);
        return existingCustomer != null ? Ok(existingCustomer) : NotFound();
    }

    /// <summary>
    /// Updates a customer.
    /// </summary>
    /// <param name="id">The ID of the customer to update.</param>
    /// <param name="customerDto">The updated customer data.</param>
    /// <returns>An IActionResult indicating the result of the update operation.</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, CustomerDto customerDto)
    {
        if (id != customerDto.Id)
        {
            return BadRequest(); 
        }
        var updatedCustomer = _customerService.EditCustomer(customerDto);
        if (updatedCustomer == null)
        {
            return NotFound(); 
        }
        else
        {
            return Ok(updatedCustomer); 
        }
    }

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    /// <param name="customerDto">The customer data to create.</param>
    /// <returns>An IActionResult indicating the result of the create operation.</returns>
    [HttpPost]
    public IActionResult CreateCustomer(CustomerDto customerDto)
    {
        var addedCustomer = _customerService.CreateCustomer(customerDto);
        return CreatedAtAction(nameof(GetCustomerById), new { id = addedCustomer.Id }, addedCustomer);
    }

    /// <summary>
    /// Deletes a customer by ID.
    /// </summary>
    /// <param name="id">The ID of the customer to delete.</param>
    /// <returns>An IActionResult indicating the result of the delete operation.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        bool successfullyDeleted = _customerService.DeleteCustomer(id);
        return successfullyDeleted ? NoContent() : NotFound();
    }
}
