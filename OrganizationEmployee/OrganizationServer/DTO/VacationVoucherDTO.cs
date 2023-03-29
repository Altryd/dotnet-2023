﻿namespace OrganizationServer.DTO;
using EmployeeDomain;
/// <summary>
/// VacationVoucher - represents a vacation voucher, that may be issued to an employee.
/// The class stores information about issue date, voucher type and also list of EmployeeVacationVoucher in
/// order to maintain many-to-many relationship.
/// </summary>
public class VacationVoucherDTO
{
    /// <summary>
    /// Id - an id of a VacationVoucher
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// IssueDate - a date, when the VacationVoucher was issued
    /// </summary>
    public DateTime IssueDate { get; set; }
    /// <summary>
    /// VoucherType - a link to VoucherType of the given voucher
    /// </summary>
    public VoucherTypeDTO? VoucherType { get; set; }
    /// <summary>
    /// EmployeeVacationVoucher - a list of EmployeeVacationVoucher objects. For more details proceed to EmployeeVacationVoucher class
    /// </summary>
    public List<EmployeeVacationVoucher> EmployeeVacationVouchers { get; set; } = new List<EmployeeVacationVoucher>();
}