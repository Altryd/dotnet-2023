﻿namespace Organization.Server.Dto;
/// <summary>
/// PostOccupationDto - represents an employee occupation.
/// </summary>
public class GetOccupationDto
{
    /// <summary>
    /// Id - an id of the occupation
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// Name - a name of the given occupation
    /// </summary>
    public string Name { get; set; } = string.Empty;
}