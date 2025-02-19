﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organization.Domain;
using Organization.Server.Dto;

namespace Organization.Server.Controllers;
/// <summary>
/// Controller for Department of an organization
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : Controller
{
    private readonly ILogger<DepartmentController> _logger;
    private readonly IDbContextFactory<EmployeeDbContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    /// A constructor of the DepartmentController
    /// </summary>
    public DepartmentController(IMapper mapper, ILogger<DepartmentController> logger,
        IDbContextFactory<EmployeeDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the departments in the organization
    /// </summary>
    /// <returns>All the departments in the organization</returns>
    [HttpGet]
    public async Task<IEnumerable<GetDepartmentDto>> Get()
    {
        _logger.LogInformation("Get departments");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<GetDepartmentDto>>(ctx.Departments);
    }
    /// <summary>
    /// The method returns a department by ID
    /// </summary>
    /// <param name="id">Department ID</param>
    /// <returns>Department with the given ID or 404 code if department is not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetDepartmentDto>> Get(int id)
    {
        _logger.LogInformation("Get department with id {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var department = ctx.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("The department with ID {id} is not found", id);
            return NotFound();
        }
        var mappedDepartment = _mapper.Map<GetDepartmentDto>(department);
        return Ok(mappedDepartment);
    }
    /// <summary>
    /// The method adds a new department into organization
    /// </summary>
    /// <param name="department">A new department that need to be added</param>
    /// <returns>Code 201 and added department, if operation is successful</returns>
    [HttpPost]
    [ProducesResponseType(typeof(GetDepartmentDto), 201)]
    public async Task<ActionResult<GetDepartmentDto>> Post([FromBody] PostDepartmentDto department)
    {
        _logger.LogInformation("POST department method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var mappedDepartment = _mapper.Map<Department>(department);
        ctx.Departments.Add(mappedDepartment);
        await ctx.SaveChangesAsync();
        return CreatedAtAction("POST", _mapper.Map<GetDepartmentDto>(mappedDepartment));
    }
    /// <summary>
    /// The method updates a department information by ID
    /// </summary>
    /// <param name="id">An ID of the department</param>
    /// <param name="newDepartment">New information of the department</param>
    /// <returns>Code 200 and updated department, if operation is successful, 
    /// code 404 otherwise</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(GetDepartmentDto), 200)]
    public async Task<ActionResult<GetDepartmentDto>> Put(int id, [FromBody] PostDepartmentDto newDepartment)
    {
        _logger.LogInformation("PUT department method with ID: {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var department = ctx.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("The department with ID {id} is not found", id);
            return NotFound();
        }
        ctx.Departments.Update(_mapper.Map(newDepartment, department));
        await ctx.SaveChangesAsync();
        var mappedDepartment = _mapper.Map<Department>(newDepartment);
        return Ok(_mapper.Map<GetDepartmentDto>(mappedDepartment));
    }
    /// <summary>
    /// The method deletes a department by ID
    /// </summary>
    /// <param name="id">An ID of the department</param>
    /// <returns>Code 200 if operation is successful, 
    /// code 404 if the department wasn't found
    /// or code 409 if there are foreign key exception</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(GetDepartmentDto), 200)]
    public async Task<ActionResult<GetDepartmentDto>> Delete(int id)
    {
        _logger.LogInformation("DELETE department method with ID: {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var department = ctx.Departments.FirstOrDefault(department => department.Id == id);
        if (department == null)
        {
            _logger.LogInformation("The department with ID {id} is not found", id);
            return NotFound();
        }
        try
        {
            ctx.Departments.Remove(department);
            await ctx.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogInformation("SQL exception while deleting the department, " +
                "exception message: ", ex.Message);
            return Conflict("Can not remove the department because some rows " +
                "in other tables are pointing on that department! " +
                "Remove them first and then try again!");
        }
        return Ok(_mapper.Map<GetDepartmentDto>(department));
    }
}
