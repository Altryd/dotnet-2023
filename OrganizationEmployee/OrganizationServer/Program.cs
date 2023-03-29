using OrganizationServer;

var builder = WebApplication.CreateBuilder(args);  //����� WebApplication, � ���� ����
//����������� ����� "CreateBuilder". ����� �������, ��� �� ������� Builder. �� ������������ ��� ����������������
//���������...

// Add services to the container.

builder.Services.AddSingleton<OrganizationRepository>();  //���� ������ ����� ���� �� ���� �����������

// builder.Services.AddTransient<OrganizationRepository>();  //������  ������ ��� ��������� ������ ��� ������ AddTransient

builder.Services.AddControllers(); // builder.Services - ���������������� ��������. ��� ��� - ��������� ���������.
//����� ������, ��� ��� �����, ����� ������, ��� ����� Dependency Injection. ���� ��������� Dependency Inversion
// ����� ������������, ��� ��� ������ ...
// ���� ��������� ������� � ���, ��� �� ������������ �������, �� �� ������� DI ����������: "������� ����������� ���".

// DependencyInjection - "�����", �������� ������ ��� DI � DC, ��������� ��� ������ �� �������.

//��� ���������� ������� - ����� Services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();  //
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSwaggerGen();  //��������� ������� ��������



var app = builder.Build();  //����� ����� ������

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();  //�� �����������

app.MapControllers();   //������ ��� ����������� �� ��������

app.Run();
