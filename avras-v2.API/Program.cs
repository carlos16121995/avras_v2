using avras_v2.API.Swagger;
using avras_v2.Application;
using avras_v2.Application.Class;
using avras_v2.Infrastructure.Persistence;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.RegisterEF<Context>(builder.Configuration);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation(builder.Configuration);

builder.Services.AddMvc(options =>
{
    options.ModelMetadataDetailsProviders.Add(new BindingSourceMetadataProvider(typeof(ClassCommandHandler), BindingSource.ModelBinding));
    options.EnableEndpointRouting = false;
    options.RespectBrowserAcceptHeader = true;
    options.ReturnHttpNotAcceptable = true;
})
.AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerDocumentation();
}

app.UseCors(delegate (CorsPolicyBuilder policyBuilder) {
    policyBuilder.SetIsOriginAllowed((o) => true)
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

await app.Services.MigrateDatabaseAsync<Context>();

app.MapControllers();

app.Run();
