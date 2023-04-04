﻿using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationEmployee.Server.Dto;
using System.Text;
namespace OrganizationEmployee.IntegrationTests;
public class WorkshopIntergrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public WorkshopIntergrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetWorkshops()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Workshop");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var workshops = JsonConvert.DeserializeObject<List<WorkshopDto>>(content);
        Assert.NotNull(workshops);
        Assert.True(workshops.Count >= 4);
    }

    [Theory]
    [InlineData(1, "Ленинский цех", true)]
    [InlineData(2, "Производственный цех", true)]
    [InlineData(1337, "", false)]
    [InlineData(555, "", false)]
    public async Task GetWorkshop(uint workshopId, string workshopName, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Format("api/Workshop/{0}", workshopId));

        var content = await response.Content.ReadAsStringAsync();
        var workshop = JsonConvert.DeserializeObject<WorkshopDto>(content);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(workshop);
            Assert.Equal(workshopName, workshop.Name);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }

    [Theory]
    [InlineData("Самарский цех")]
    [InlineData("Московский цех")]
    public async Task PostWorkshop(string workshopName)
    {
        var workshopDto = new WorkshopDto()
        {
            Name = workshopName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(workshopDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PostAsync("api/Workshop", stringContent);
        Assert.True(response.IsSuccessStatusCode);
    }

    [Theory]
    [InlineData(4, "Екатеринбургский цех", true)]
    [InlineData(155, "Московский цех", false)]
    public async Task PutWorkshop(uint workshopId, string workshopName, bool isSuccess)
    {
        var departmentDto = new WorkshopDto()
        {
            Name = workshopName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(departmentDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PutAsync(string.Format("api/Workshop/{0}", workshopId), stringContent);

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

    [Theory]
    [InlineData(5, true)]
    [InlineData(133, false)]
    public async Task DeleteWorkshop(int workshopId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync(string.Format("api/Workshop/{0}", workshopId));
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