using AddressBookWebApi.DbContext;
using AddressBookWebApi.Profiles;
using AddressBookWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ApplicationDbContext>();

builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<ContactMappingProfile>();
});

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("AllowAllHeader", options =>
    {
        options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllHeader");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
