namespace UnitTestLR1;

using EmployeeDomain;
using EmployeeDomainTests;
using System.Linq;  // ��� ��������

public class EmployeeDomainTestClass : IClassFixture<EmployeeFixture>   //���� ����� �� ����� ���� ����������� �� Object
{
    // ���������� ����� � ������
    // ����� - ������, ��������� ���� �����
    // ������ - ��������� ��������� �������� (?)
    private readonly EmployeeFixture _fixture;
    public EmployeeDomainTestClass(EmployeeFixture fixture)
    {
        _fixture = fixture;
    }
    [Fact]
    public void TestInts()
    {
        var a = 0;
        var b = 2;
        var c = a + b;
        Assert.Equal(2, c);
    }
    [Fact]
    public void TestFirstQuery()
    {
        var workshopList = _fixture.WorkshopFixture;
        /*
        var workshopFirst = new Workshop
        {
            Name = "��������� ���",
            Id = 1,
            Employees = new List<Employee>()
        };
        var workshopSecond = new Workshop
        {
            Name = "���������������� ���",
            Id = 2,
            Employees = new List<Employee>()
        };
        var workshopThird = new Workshop
        {
            Name = "��������� ���",
            Id = 3,
            Employees = new List<Employee>()
        };
        var workshopFourth = new Workshop
        {
            Name = "�������� ���",
            Id = 4,
            Employees = new List<Employee>()
        };
        var workshopFifth = new Workshop
        {
            Name = "������������ ���",
            Id = 5,
            Employees = new List<Employee>()
        };
        var workshopSixth = new Workshop
        {
            Name = "����������� ���",
            Id = 6,
            Employees = new List<Employee>()
        };*/
        var occupationFirst = new Occupation
        {
            Name = "�������� ������",
            Id = 0,
            EmployeeOccupation = new List<EmployeeOccupation>()
        };
        var occupationSecond = new Occupation
        {
            Name = "�����������",
            Id = 1,
            EmployeeOccupation = new List<EmployeeOccupation>()
        };
        var occupationThird = new Occupation
        {
            Name = "�����������",
            Id = 2,
            EmployeeOccupation = new List<EmployeeOccupation>()
        };
        var departmentFirst = new Department
        {
            Name = "����� ��",
            Id = 1
        };
        var departmentSecond = new Department
        {
            Name = "����� ����������������",
            Id = 2
        };
        var departmentThird = new Department
        {
            Name = "����� ������",
            Id = 3
        };
        var departmentList = new List<Department>
        {
            new Department
            {
                Name = "����� ��",
                Id = 1
            },
            new Department
            {
                Name = "����� ����������������",
                Id = 2
            },
            new Department
            {
                Name = "����� ������",
                Id = 3
            },
            new Department
            {
                Name = "����� �����������",
                Id=4
            },
            new Department
            {
                Name = "����� �����������",
                Id = 5
            },
            new Department
            {
                Name = "����� ��������� ������",
                Id = 6
            },
            new Department
            {
                Name = "����� ������������",
                Id = 7
            },
            new Department
            {
                Name = "����������� �����",
                Id = 8
            },
            new Department
            {
                Name = "����� ���������",
                Id = 9
            },
            new Department
            {
                Name = "����� ��������� � �������",
                Id = 10
            }
        };
        var voucherTypeFirst = new VoucherType
        {
            Name = "���������",
            Id = 0,
            VacationVoucher = new List<VacationVoucher>()
        };
        var voucherTypeSecond = new VoucherType
        {
            Name = "��� ������",
            Id = 1,
            VacationVoucher = new List<VacationVoucher>()
        };
        var voucherTypeThird = new VoucherType
        {
            Name = "���������� ������ �����������",
            Id = 2,
            VacationVoucher = new List<VacationVoucher>()
        };
        var employees = new List<Employee>()
        {
            new Employee(Guid.NewGuid(), 1337, "���������", "���������", "����������", new DateOnly(1978, 3, 22), workshopList[4],
            "���. ��������, ��.����������� �.35", "89633154365", "88462322442", "�����", 4, 2, new List<EmployeeOccupation>(),
            new List<DepartmentEmployee>(), new List<EmployeeVacationVoucher>()
            ),
            new Employee(Guid.NewGuid(), 443, "������", "�����", "���������", new DateOnly(2000, 1, 23), workshopList[5],
            "�.������, ��.������, �.57", "89633154365", "88462322442", "������", 3, 0, new List<EmployeeOccupation>(),
            new List<DepartmentEmployee>(), new List<EmployeeVacationVoucher>()
            ),
            new Employee(Guid.NewGuid(), 3, "������", "������", "��������", new DateOnly(1978, 8, 6), workshopList[5],
            "�.������ ���������� �����, �.108", "89633154365", "88462322442", "�����", 5, 3, new List<EmployeeOccupation>(),
            new List<DepartmentEmployee>(), new List<EmployeeVacationVoucher>()
            ),
            new Employee(Guid.NewGuid(), 7, "�����", "���������", "�����������", new DateOnly(1980, 10, 10), workshopList[0],
            "���.�������� ��.������ �.43", "89633154365", "88462322442", "�������", 3, 1, new List<EmployeeOccupation>(),
            new List<DepartmentEmployee>(), new List<EmployeeVacationVoucher>()
            )
        };
        workshopList[4].Employees.Add(employees[0]);
        workshopList[5].Employees.Add(employees[1]);
        workshopList[5].Employees.Add(employees[2]);
        workshopList[0].Employees.Add(employees[3]);
        var departmentEmployeeFirst = new DepartmentEmployee
        {
            Department = departmentList[0],
            Employee = employees[0],
            Id = 1
        };
        var departmentEmployeeSecond = new DepartmentEmployee
        {
            Department = departmentList[1],
            Employee = employees[0],
            Id = 2
        };
        var departmentEmployeeThird = new DepartmentEmployee
        {
            Department = departmentList[1],
            Employee = employees[1],
            Id = 3
        };
        var departmentEmployeeFourth = new DepartmentEmployee
        {
            Department = departmentList[0],
            Employee = employees[2],
            Id = 4
        };
        var departmentEmployeeFifth = new DepartmentEmployee
        {
            Department = departmentList[0],
            Employee = employees[1],
            Id = 5
        };
        var departmentEmployeeSixth = new DepartmentEmployee
        {
            Department = departmentList[1],
            Employee = employees[2],
            Id = 6
        };
        var departmentEmployeeSeventh = new DepartmentEmployee
        {
            Department = departmentList[1],
            Employee = employees[3],
            Id = 7
        };
        employees[0].DepartmentEmployee.Add(departmentEmployeeFirst);
        employees[0].DepartmentEmployee.Add(departmentEmployeeSecond);
        employees[1].DepartmentEmployee.Add(departmentEmployeeThird);
        employees[1].DepartmentEmployee.Add(departmentEmployeeFifth);
        employees[2].DepartmentEmployee.Add(departmentEmployeeFourth);
        employees[2].DepartmentEmployee.Add(departmentEmployeeSixth);
        employees[3].DepartmentEmployee.Add(departmentEmployeeSeventh);
        var departmentEmployeeList = new List<DepartmentEmployee>
        {
            departmentEmployeeFirst,
            departmentEmployeeSecond,
            departmentEmployeeThird,
            departmentEmployeeFourth,
            departmentEmployeeFifth,
            departmentEmployeeSixth,
            departmentEmployeeSeventh
        };
        var requestFirst = (from employee in employees
                            join departmentEmployeeItem in departmentEmployeeList on employee equals departmentEmployeeItem.Employee
                            join department in departmentList on departmentEmployeeItem.Department equals department
                            where department.Id == 1
                            select employee).ToList();
        Assert.Equal(3, requestFirst.Count);

        var requestSecond = (from employee in employees
                             orderby employee.LastName, employee.FirstName, employee.PatronymicName
                             join departmentEmployeeItem in departmentEmployeeList on employee equals departmentEmployeeItem.Employee
                             join department in departmentList on departmentEmployeeItem.Department equals department
                             group employee by new { employee.Id, employee.LastName, employee.FirstName, employee.PatronymicName } into grp
                             where grp.Count() > 1
                             orderby grp.Key.LastName, grp.Key.FirstName, grp.Key.PatronymicName
                             select new
                             {
                                 Id = grp.Key.Id,
                                 FirstName = grp.Key.FirstName,
                                 LastName = grp.Key.LastName,
                                 PatronymicName = grp.Key.PatronymicName,
                                 CountDepart = grp.Count()
                             }).ToList();
        Assert.Equal(3, requestSecond.Count);

        //TODO: requestThird

        var requestFourth = 
            (from tuple in (
                                from employee in employees
                                 join departmentEmployeeItem in departmentEmployeeList on employee equals departmentEmployeeItem.Employee
                                 join department in departmentList on departmentEmployeeItem.Department equals department
                                 select new
                                 {
                                     employeeAge = (DateOnly.FromDateTime(DateTime.Now).DayNumber - employee.BirthDate.DayNumber) / 365.2425,
                                     departmentId = department.Id
                                 }   //��������� �����, ����� ������ ������..
                            )
               group tuple by tuple.departmentId into grp
               select new
               {
                   averageAge = grp.Average(empl => empl.employeeAge),
                   departmentId = grp.Key
               }).ToList();
        Assert.NotEqual(requestFourth[0].averageAge, requestFourth[1].averageAge);
        var ky2 = 5;
    }
}