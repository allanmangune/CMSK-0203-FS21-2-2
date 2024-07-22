using Assignment1Api.Core;
using Assignment1Api.Entities;
using AutoMapper;

namespace Assignment1Api.Core 
{
    /// <summary>
    /// Represents the application profile for AutoMapper configuration.
    /// </summary>
    public class ApplicationProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationProfile"/> class.
        /// </summary>
        public ApplicationProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
