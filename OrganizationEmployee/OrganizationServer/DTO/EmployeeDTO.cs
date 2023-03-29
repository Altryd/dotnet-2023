﻿namespace OrganizationServer.DTO;
/// <summary>
/// Classs Employee represents an employee in organization, it contains personal information and
/// it has lists of other classes -  EmployeeOccupation, DepartmentEmployee, EmployeeVacationVoucher to represent many-to-many relationship.
/// It also has a link to Workshop class for one-to-many relationship.
/// </summary>
public class EmployeeDTO
{
    /// <summary>
    /// RegNumber - registration number of an Employee
    /// </summary>
    public uint RegNumber { get; set; }
    /// <summary>
    /// FirstName - first name of an Employee
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// LastName - last name of an Employee
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// LastName - patronymic name of on Employee
    /// </summary>
    public string PatronymicName { get; set; } = string.Empty;
    /// <summary>
    /// BirthDate - birth date of an Employee
    /// </summary>
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    /// <summary>
    /// Workshop - an workshop, where the employee is working
    /// </summary>
    public int WorkshopId { get; set; }  // добавить подобное везде!
    /// <summary>
    /// HomeAddress - home address of an employee
    /// </summary>
    public string HomeAddress { get; set; } = string.Empty;
    /// <summary>
    /// HomeTelephone - home telephone of an employee
    /// </summary>
    public string HomeTelephone { get; set; } = string.Empty;
    /// <summary>
    /// Work Telephone - work telephone of an employee
    /// </summary>
    public string WorkTelephone { get; set; } = string.Empty;
    /// <summary>
    /// FamilyStatus - family status of an employee (ex. "married", "single")
    /// </summary>
    public string FamilyStatus { get; set; } = string.Empty;
    /// <summary>
    /// FamilyMembersCount - number of people in the employee's family
    /// </summary>
    public uint FamilyMembersCount { get; set; } = 1;
    /// <summary>
    /// ChildrenCount - number of the employee's children
    /// </summary>
    public uint ChildrenCount { get; set; } = 0;
}