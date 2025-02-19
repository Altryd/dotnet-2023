﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organization.Domain;
using Organization.Server.Dto;

namespace Organization.Server.Controllers;
/// <summary>
/// Controller for Occupation class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OccupationController : Controller
{
    private readonly ILogger<OccupationController> _logger;
    private readonly IDbContextFactory<EmployeeDbContext> _contextFactory;
    private readonly IMapper _mapper;
    /// <summary>
    /// A constructor of the OccupationController
    /// </summary>
    public OccupationController(IDbContextFactory<EmployeeDbContext> contextFactory, IMapper mapper,
        ILogger<OccupationController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }
    /// <summary>
    /// The method returns all the occupations in the organization
    /// </summary>
    /// <returns>All the occupations in the organization</returns>
    [HttpGet]
    public async Task<IEnumerable<GetOccupationDto>> Get()
    {
        _logger.LogInformation("Get occupations");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<GetOccupationDto>>(ctx.Occupations);
    }
    /// <summary>
    /// The method returns an occupation by ID
    /// </summary>
    /// <param name="id">Occupation ID</param>
    /// <returns>Occupation with the given ID or 404 code if occupation is not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GetOccupationDto>> Get(int id)
    {
        _logger.LogInformation("Get occupation with id {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var occupation = ctx.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null)
        {
            _logger.LogInformation("The occupation with ID {id} is not found", id);
            return NotFound();
        }
        var mappedOccupation = _mapper.Map<GetOccupationDto>(occupation);
        return Ok(mappedOccupation);
    }
    /// <summary>
    /// The method adds a new occupation into organization
    /// </summary>
    /// <param name="occupation">A new occupation that needs to be added</param>
    /// <returns>Code 201 with an added occupation</returns>
    [HttpPost]
    [ProducesResponseType(typeof(GetOccupationDto), 201)]
    public async Task<ActionResult<GetOccupationDto>> Post([FromBody] PostOccupationDto occupation)
    {
        _logger.LogInformation("POST occupation method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var mappedOccupation = _mapper.Map<Occupation>(occupation);
        ctx.Occupations.Add(mappedOccupation);
        await ctx.SaveChangesAsync();
        return CreatedAtAction("POST", _mapper.Map<GetOccupationDto>(mappedOccupation));
    }
    /// <summary>
    /// The method updates an occupation information by ID
    /// </summary>
    /// <param name="id">An ID of the occupation</param>
    /// <param name="newOccupation">New information of the occupation</param>
    /// <returns>Code 200 and the updated occupation class if success; 
    /// 404 code if an occupation is not found;</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GetOccupationDto>> Put(int id, [FromBody] PostOccupationDto newOccupation)
    {
        _logger.LogInformation("PUT occupation method");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var occupation = ctx.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null)
        {
            _logger.LogInformation("The occupation with ID {id} is not found", id);
            return NotFound("The occupation with given id is not found");
        }
        ctx.Occupations.Update(_mapper.Map(newOccupation, occupation));
        await ctx.SaveChangesAsync();
        var mappedOccupation = _mapper.Map<Occupation>(newOccupation);
        return Ok(_mapper.Map<GetOccupationDto>(mappedOccupation));
    }
    /// <summary>
    /// The method deletes an occupation by ID
    /// </summary>
    /// <param name="id">An ID of the occupation</param>
    /// <returns>Code 200 if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<GetOccupationDto>> Delete(int id)
    {
        _logger.LogInformation("DELETE occupation method with ID: {id}", id);
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var occupation = ctx.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null)
        {
            _logger.LogInformation("The occupation with ID {id} is not found", id);
            return NotFound("The occupation with given id is not found");
        }
        ctx.Occupations.Remove(occupation);
        try
        {
            await ctx.SaveChangesAsync();
        }
        catch (DbUpdateException exception)
        {
            _logger.LogInformation("SQL exception while deleting the occupation, " +
                "exception message: ", exception.Message);
            return Conflict("Can not remove the occupation because some rows " +
                "in other tables are pointing on that occupation! " +
                "Remove them first and then try again!");
        }
        return Ok(_mapper.Map<GetOccupationDto>(occupation));
    }
}
