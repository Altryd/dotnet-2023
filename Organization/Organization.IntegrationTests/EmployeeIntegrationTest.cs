﻿using Microsoft.AspNetCore.Mvc.Testing;
using Organization.Server.Dto;
using System.Text;
using System.Text.Json;
namespace Organization.IntegrationTests;
/// <summary>
/// EmployeeIntegrationTest  - represents a integration test of EmployeeController
/// </summary>
[Collection("Sequential")]
public class EmployeeIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    /// <summary>
    /// _serializeOptions - options for JsonSerializer
    /// </summary>
    private readonly JsonSerializerOptions _serializeOptions;
    /// <summary>
    /// A constructor of the EmployeeIntegrationTest
    /// </summary>
    public EmployeeIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
    /// <summary>
    /// Tests the parameterless GET method
    /// </summary>
    [Fact]
    public async Task GetEmployees()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Employee");

        var content = await response.Content.ReadAsStringAsync();
        var employees = JsonSerializer.Deserialize<List<GetEmployeeDto>>(content, _serializeOptions);
        Assert.NotNull(employees);
        Assert.True(employees.Count >= 3);
    }
    /// <summary>
    /// Tests the parameterized GET method
    /// </summary>
    /// <param name="employeeId">ID of the Employee</param>
    /// <param name="employeeRegNumber">Correct registration number of the Employee</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(1, 1337, true)]
    [InlineData(3, 3, true)]
    [InlineData(4, 5, true)]
    [InlineData(1337, 0, false)]
    [InlineData(555, 0, false)]
    public async Task GetEmployee(uint employeeId, uint employeeRegNumber, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"api/Employee/{employeeId}");

        var content = await response.Content.ReadAsStringAsync();
        var employee = JsonSerializer.Deserialize<GetEmployeeDto>(content, _serializeOptions);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(employee);
            Assert.Equal(employeeRegNumber, employee.RegNumber);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    /// <summary>
    /// Tests the POST method
    /// </summary>
    /// <param name="regNumber">The registration number of the new Employee</param>
    /// <param name="firstName">First name of the new Employee</param>
    /// <param name="lastName">Last name of the new Employee</param>
    /// <param name="patronymicName">Patronymic name of the new Employee</param>
    /// <param name="birthYear">Birth year of the new Employee</param>
    /// <param name="birthMonth">Birth month of the new Employee</param>
    /// <param name="birthDay">Birth day of the new Employee</param>
    /// <param name="workshopId">Workshop ID of the new Employee</param>
    /// <param name="homeAddress">Home address of the new Employee</param>
    /// <param name="homeTelephone">Home telephone of the new Employee</param>
    /// <param name="workTelephone">Work telephone of the new Employee</param>
    /// <param name="familyStatus">Family status of the new Employee</param>
    /// <param name="familyMembersCount">The number of family members of the new Employee</param>
    /// <param name="childrenCount">The number of children of the new Employee</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(1456, "Иван", "Иванов", "Иванович", 2000, 10, 28, 1, "г.Самара Московское шоссе, д.12",
        "89633154365", "88005553535", "холост", 2, 0, true)]
    [InlineData(1456, "Иван", "Иванов", "Иванович", 2000, 10, 28, 0, "г.Самара Московское шоссе, д.12",
    "89633154365", "88005553535", "холост", 2, 0, false)]
    [InlineData(1337, "Иван", "Иванов", "Иванович", 2000, 10, 28, 1, "г.Самара Московское шоссе, д.12",
    "89633154365", "88005553535", "холост", 2, 0, false)]
    public async Task PostEmployee(uint regNumber, string firstName, string lastName, string patronymicName,
        int birthYear, int birthMonth, int birthDay, int workshopId, string homeAddress, string homeTelephone,
        string workTelephone, string familyStatus, uint familyMembersCount, uint childrenCount, bool isSuccess)
    {
        var employeeDto = new PostEmployeeDto()
        {
            RegNumber = regNumber,
            FirstName = firstName,
            LastName = lastName,
            PatronymicName = patronymicName,
            BirthDate = new DateTime(birthYear, birthMonth, birthDay),
            WorkshopId = workshopId,
            HomeAddress = homeAddress,
            HomeTelephone = homeTelephone,
            WorkTelephone = workTelephone,
            FamilyStatus = familyStatus,
            FamilyMembersCount = familyMembersCount,
            ChildrenCount = childrenCount
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(employeeDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("api/Employee", stringContent);

        var content = await response.Content.ReadAsStringAsync();
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    /// <summary>
    /// Tests the PUT method
    /// </summary>
    /// <param name="employeeId">The ID of the existing Employee</param>
    /// <param name="regNumber">The new registration number of the Employee</param>
    /// <param name="firstName">The new first name of the Employee</param>
    /// <param name="lastName">The new last name of the Employee</param>
    /// <param name="patronymicName">The new patronymic name of the new Employee</param>
    /// <param name="birthYear">The new birth year of the Employee</param>
    /// <param name="birthMonth">The new birth month of the Employee</param>
    /// <param name="birthDay">The new birth day of the Employee</param>
    /// <param name="workshopId">The new workshop ID of the Employee</param>
    /// <param name="homeAddress">The new home address of the Employee</param>
    /// <param name="homeTelephone">The new home telephone of the Employee</param>
    /// <param name="workTelephone">The new ork telephone of the Employee</param>
    /// <param name="familyStatus">The new family status of the Employee</param>
    /// <param name="familyMembersCount">The new number of family members of the Employee</param>
    /// <param name="childrenCount">The new number of children of the Employee</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(2, 888, "Иван", "Иванов", "Иванович", 2000, 10, 28, 1, "г.Самара Московское шоссе, д.12",
        "89633154365", "88005553535", "холост", 2, 0, true)]
    [InlineData(2, 888, "Иван", "Иванов", "Иванович", 2000, 10, 28, 0, "г.Самара Московское шоссе, д.12",
        "89633154365", "88005553535", "холост", 2, 0, false)]
    [InlineData(5653, 888, "Иван", "Иванов", "Иванович", 2000, 10, 28, 1, "г.Самара Московское шоссе, д.12",
        "89633154365", "88005553535", "холост", 2, 0, false)]
    public async Task PutEmployee(uint employeeId, uint regNumber, string firstName, string lastName, string patronymicName,
        int birthYear, int birthMonth, int birthDay, int workshopId, string homeAddress, string homeTelephone,
        string workTelephone, string familyStatus, uint familyMembersCount, uint childrenCount, bool isSuccess)
    {
        var employeeDto = new PostEmployeeDto()
        {
            RegNumber = regNumber,
            FirstName = firstName,
            LastName = lastName,
            PatronymicName = patronymicName,
            BirthDate = new DateTime(birthYear, birthMonth, birthDay),
            WorkshopId = workshopId,
            HomeAddress = homeAddress,
            HomeTelephone = homeTelephone,
            WorkTelephone = workTelephone,
            FamilyStatus = familyStatus,
            FamilyMembersCount = familyMembersCount,
            ChildrenCount = childrenCount
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonSerializer.Serialize(employeeDto, _serializeOptions);
        var stringContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"api/Employee/{employeeId}", stringContent);

        var content = await response.Content.ReadAsStringAsync();
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }

    /// <summary>
    /// Tests the DELETE method
    /// </summary>
    /// <param name="employeeId">The ID of the existing Employee</param>
    /// <param name="isSuccess">Specifies the correct outcome (success/fail)</param>
    [Theory]
    [InlineData(77, true)]
    [InlineData(133, false)]
    public async Task DeleteEmployee(int employeeId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync($"api/Employee/{employeeId}");
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
}