﻿namespace EmployeeDomain;
public class VoucherType
{
    /// <summary>
    /// Id - an id of a VoucherType
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// Name - a name of a VoucherType
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// VacationVoucher - a list of VacationVoucher objects. For more details proceed to VacationVoucher class
    /// </summary>
    public List<VacationVoucher> VacationVoucher { get; set; } = new List<VacationVoucher>();
}
