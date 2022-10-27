using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Text;
using System;
using static System.Net.WebRequestMethods;
using System.Buffers.Text;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Routing;
using System.Security.Policy;
using Contracts;
using System.Linq;
using Entities.DataTransferObjects;
using AutoMapper;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CompanyEmployeesWebAPI.Controllers
{
    //This attribute represents routing
    //Web API routing routes incoming HTTP requests to the particular action
    //method inside the Web API controller.As soon as we send our HTTP
    //request, the MVC framework parses that request and tries to match it to
    //an action in the controller.
    //There are two ways to implement routing in the project:
    // Convention based routing and
    // Attribute routing
    [Route("api/companies")]
    [ApiController]
    //Controllers should only be responsible for handling requests, model
    //validation, and returning responses to the frontend or some HTTP client.
    //Keeping business logic away from controllers is a good way to keep them
    //lightweight, and our code more readable and maintainable.

    //While working with the Web API project, the ASP.NET Core team suggests
    //that we shouldn’t use Convention-based Routing, but Attribute routing
    //instead.

    //Different actions can be executed on the resource with the same URI, but
    //with different HTTP Methods.In the same manner for different actions, we
    //can use the same HTTP Method, but different URIs.

    //The resource name in the URI should always be a noun(sustantivo) and not an action. 
    //we should create this route: api/companies and not this one:/api/getCompanies.
    //The noun used in URI represents the resource and helps the consumer to
    //understand what type of resource we are working with
    public class CompaniesController : ControllerBase
    {
        //private readonly IRepositoryManager _repository;
        //private readonly ILoggerManager _logger;
        ////private readonly IMapper _mapper;

        //public CompaniesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) 
        //{
        //    _repository = repository;
        //    _logger = logger;
        //    //_mapper = mapper;
        //}

        //[HttpGet]
        //public IActionResult GetCompanies() 
        //{
        //    try
        //    {
        //        //var companies = _repository.Company.GetAllCompanies(trackChanges: false);
        //        //var companiesDto = companies.Select(c => new CompanyDto
        //        //{
        //        //    Id = c.Id,
        //        //    Name = c.Name,
        //        //    FullAddress = String.Join(" ", c.Address, c.Country)
        //        //}).ToList();
        //        //var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        //        //return Ok(companies);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Comething went wrong in the {nameof(GetCompanies)} action {ex}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetCompany(Guid id) 
        //{
        //    var company = _repository.Company.GetCompany(id, trackChanges: false);
        //    if(company == null) 
        //    {
        //        _logger.LogInfo($"Company with id: {id} doesn´t exist in the database.");
        //        return NotFound();
        //    }
        //    else 
        //    {
        //        var companyDto = _mapper.Map<CompanyDto>(company);
        //        return Ok(companyDto);
        //    }
        //}
    }
}
