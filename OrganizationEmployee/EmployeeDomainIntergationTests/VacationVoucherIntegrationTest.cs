﻿using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationServer.Dto;
using System.Text;
namespace EmployeeDomain.IntegrationTests;
public class VacationVoucherIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public VacationVoucherIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetVacationVouchers()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/VacationVoucher");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var vacationVouchers = JsonConvert.DeserializeObject<List<VacationVoucherDto>>(content);
        Assert.NotNull(vacationVouchers);
        Assert.True(vacationVouchers.Count >= 1);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(1337, false)]
    [InlineData(555, false)]
    public async Task GetVacationVoucher(uint vactionVoucherId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Format("api/VacationVoucher/{0}", vactionVoucherId));

        var content = await response.Content.ReadAsStringAsync();
        var vacationVoucher = JsonConvert.DeserializeObject<VacationVoucherDto>(content);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(vacationVoucher);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }
    
    [Theory]
    [InlineData(2020, 11, 23, 0, true)]
    [InlineData(2011, 3, 15, 1, true)]
    [InlineData(2011, 3, 15, 33, false)]
    public async Task PostVacationVoucher(int issueYear, int issueMonth, int issueDay, 
        uint voucherTypeId, bool isSuccess)
    {
        var vacationVoucherDto = new VacationVoucherDto()
        {
            IssueDate = new DateTime(issueYear, issueMonth, issueDay),
            VoucherTypeId = voucherTypeId
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(vacationVoucherDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PostAsync("api/VacationVoucher", stringContent);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }

    [Theory]
    [InlineData(2, 2020, 11, 23, 0, true)]
    [InlineData(2, 2020, 11, 23, 55, false)]
    [InlineData(55, 2011, 3, 15, 0, false)]
    public async Task PutVacationVoucher(uint vacationVoucherId, int issueYear, int issueMonth, int issueDay,
        uint voucherTypeId, bool isSuccess)
    {
        var vacationVoucherDto = new VacationVoucherDto()
        {
            IssueDate = new DateTime(issueYear, issueMonth, issueDay),
            VoucherTypeId = voucherTypeId
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(vacationVoucherDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PutAsync(string.Format("api/VacationVoucher/{0}", vacationVoucherId), stringContent);

        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }

    [Theory]
    [InlineData(3, true)]
    [InlineData(133, false)]
    public async Task DeleteVacationVoucher(int vacationVoucherId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync(string.Format("api/VacationVoucher/{0}", vacationVoucherId));
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