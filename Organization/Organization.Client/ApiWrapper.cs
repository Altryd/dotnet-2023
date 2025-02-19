﻿using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
namespace Organization.Client;
public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;

        _client = new ApiClient(serverUrl, new HttpClient());
    }
    public Task<ICollection<GetDepartmentEmployeeDto>> GetDepartmentEmployeesAsync()
    {
        return _client.DepartmentEmployeeAllAsync();
    }

    public Task<GetDepartmentEmployeeDto> AddDepartmentEmployeeAsync
        (PostDepartmentEmployeeDto departmentEmployee)
    {
        return _client.DepartmentEmployeePOSTAsync(departmentEmployee);
    }

    public Task<GetDepartmentEmployeeDto> UpdateDepartmentEmployeeAsync(int id,
        PostDepartmentEmployeeDto departmentEmployee)
    {
        return _client.DepartmentEmployeePUTAsync(id, departmentEmployee);
    }

    public Task<GetDepartmentEmployeeDto> DeleteDepartmentEmployeeAsync(int id)
    {
        return _client.DepartmentEmployeeDELETEAsync(id);
    }

    public Task<ICollection<GetDepartmentDto>> GetDepartmentsAsync()
    {
        return _client.DepartmentAllAsync();
    }

    public Task<GetDepartmentDto> AddDepartmentAsync(PostDepartmentDto department)
    {
        return _client.DepartmentPOSTAsync(department);
    }

    public Task<GetDepartmentDto> UpdateDepartmentAsync(int id, PostDepartmentDto department)
    {
        return _client.DepartmentPUTAsync(id, department);
    }

    public Task<GetDepartmentDto> DeleteDepartmentAsync(int id)
    {
        return _client.DepartmentDELETEAsync(id);
    }

    public Task<ICollection<GetEmployeeOccupationDto>> GetEmployeeOccupationsAsync()
    {
        return _client.EmployeeOccupationAllAsync();
    }

    public Task<GetEmployeeOccupationDto> AddEmployeeOccupationAsync
        (PostEmployeeOccupationDto employeeOccupation)
    {
        return _client.EmployeeOccupationPOSTAsync(employeeOccupation);
    }

    public Task<GetEmployeeOccupationDto> UpdateEmployeeOccupationAsync(int id,
        PostEmployeeOccupationDto employeeOccupation)
    {
        return _client.EmployeeOccupationPUTAsync(id, employeeOccupation);
    }

    public Task<GetEmployeeOccupationDto> DeleteEmployeeOccupationAsync(int id)
    {
        return _client.EmployeeOccupationDELETEAsync(id);
    }

    public Task<ICollection<GetEmployeeDto>> GetEmployeesAsync()
    {
        return _client.EmployeeAllAsync();
    }

    public Task<GetEmployeeDto> AddEmployeeAsync(PostEmployeeDto employee)
    {
        return _client.EmployeePOSTAsync(employee);
    }

    public Task<GetEmployeeDto> UpdateEmployeeAsync(int id, PostEmployeeDto employee)
    {
        return _client.EmployeePUTAsync(id, employee);
    }

    public Task<GetEmployeeDto> DeleteEmployeeAsync(int id)
    {
        return _client.EmployeeDELETEAsync(id);
    }

    public Task<ICollection<GetEmployeeVacationVoucherDto>> GetEmployeeVacationVouchersAsync()
    {
        return _client.EmployeeVacationVoucherAllAsync();
    }

    public Task<GetEmployeeVacationVoucherDto> AddEmployeeVacationVoucherAsync
        (PostEmployeeVacationVoucherDto employeeVacationVoucher)
    {
        return _client.EmployeeVacationVoucherPOSTAsync(employeeVacationVoucher);
    }

    public Task<GetEmployeeVacationVoucherDto> UpdateEmployeeVacationVoucherAsync
        (int id, PostEmployeeVacationVoucherDto employeeVacationVoucher)
    {
        return _client.EmployeeVacationVoucherPUTAsync(id, employeeVacationVoucher);
    }

    public Task<GetEmployeeVacationVoucherDto> DeleteEmployeeVacationVoucherAsync(int id)
    {
        return _client.EmployeeVacationVoucherDELETEAsync(id);
    }


    public Task<ICollection<GetOccupationDto>> GetOccupationsAsync()
    {
        return _client.OccupationAllAsync();
    }

    public Task<GetOccupationDto> AddOccupationAsync(PostOccupationDto occupation)
    {
        return _client.OccupationPOSTAsync(occupation);
    }

    public Task<GetOccupationDto> UpdateOccupationAsync(int id, PostOccupationDto occupation)
    {
        return _client.OccupationPUTAsync(id, occupation);
    }

    public Task<GetOccupationDto> DeleteOccupationAsync(int id)
    {
        return _client.OccupationDELETEAsync(id);
    }



    public Task<ICollection<GetVacationVoucherDto>> GetVacationVouchersAsync()
    {
        return _client.VacationVoucherAllAsync();
    }

    public Task<GetVacationVoucherDto> AddVacationVoucherAsync(PostVacationVoucherDto vacationVoucher)
    {
        return _client.VacationVoucherPOSTAsync(vacationVoucher);
    }

    public Task<GetVacationVoucherDto> UpdateVacationVoucherAsync(int id, PostVacationVoucherDto vacationVoucher)
    {
        return _client.VacationVoucherPUTAsync(id, vacationVoucher);
    }

    public Task<GetVacationVoucherDto> DeleteVacationVoucherAsync(int id)
    {
        return _client.VacationVoucherDELETEAsync(id);
    }

    public Task<ICollection<GetVoucherTypeDto>> GetVoucherTypesAsync()
    {
        return _client.VoucherTypeAllAsync();
    }

    public Task<GetVoucherTypeDto> AddVoucherTypeAsync(PostVoucherTypeDto voucherType)
    {
        return _client.VoucherTypePOSTAsync(voucherType);
    }

    public Task<GetVoucherTypeDto> UpdateVoucherTypeAsync(int id, PostVoucherTypeDto voucherType)
    {
        return _client.VoucherTypePUTAsync(id, voucherType);
    }

    public Task<GetVoucherTypeDto> DeleteVoucherTypeAsync(int id)
    {
        return _client.VoucherTypeDELETEAsync(id);
    }


    public Task<ICollection<GetWorkshopDto>> GetWorkshopsAsync()
    {
        return _client.WorkshopAllAsync();
    }

    public Task<GetWorkshopDto> AddWorkshopAsync(PostWorkshopDto workshop)
    {
        return _client.WorkshopPOSTAsync(workshop);
    }

    public Task<GetWorkshopDto> UpdateWorkshopAsync(int id, PostWorkshopDto workshop)
    {
        return _client.WorkshopPUTAsync(id, workshop);
    }

    public Task<GetWorkshopDto> DeleteWorkshopAsync(int id)
    {
        return _client.WorkshopDELETEAsync(id);
    }

    public Task<ICollection<EmployeeWithFewDepartmentsDto>> GetEmployeesWithFewDepartments()
    {
        return _client.EmployeesWithFewDepartmentsAsync();
    }

    public Task<ICollection<ArchiveOfDismissalsDto>> GetArchiveofDismissals()
    {
        return _client.ArchiveOfDismissalsAsync();
    }

    public Task<ICollection<AverageAgeInDepartmentDto>> GetAverageAgeInDepartments()
    {
        return _client.AvgAgeInDepartmentsAsync();
    }

    public Task<ICollection<EmployeeLastYearVoucherDto>> GetEmployeesWithLastYearVoucher()
    {
        return _client.EmployeeLastYearVoucherAsync();
    }

    public Task<ICollection<EmployeeWorkExperienceDto>> GetEmployeesWithLongestWorkExperience()
    {
        return _client.EmployeeWithLongestWorkExperienceAsync();
    }

    public Task<ICollection<GetEmployeeDto>> GetEmployeesInDepartment(int id)
    {
        return _client.DepartmentIdAsync(id);
    }
}
