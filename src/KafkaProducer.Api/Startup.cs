using System;
using System.IO;
using KafkaProducer.Api.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models; 
using Swashbuckle.AspNetCore.Filters; 

namespace KafkaProducer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddControllers();  

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {               
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "KafkaProducer API",
                    Description = "A simple Kafka Producer extension for produce data to kafka topic in ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Barış Gül", 
                        Url = new Uri("https://barisgul.github.io"),
                    } 
                });
                

                // c.ExampleFilters();

                //c.OperationFilter<AddHeaderOperationFilter>("correlationId", "Correlation Id for the request", false); // adds any string you like to the request headers - in this case, a correlation id
                //c.OperationFilter<AddResponseHeadersFilter>(); // [SwaggerResponseHeader]

                //var filePath = Path.Combine(AppContext.BaseDirectory, "WebApi.xml");
                //c.IncludeXmlComments(filePath); // standard Swashbuckle functionality, this needs to be before c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>()

                //c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>(); // Adds "(Auth)" to the summary so that you can see which endpoints have Authorization
                //                                                              // or use the generic method, e.g. c.OperationFilter<AppendAuthorizeToSummaryOperationFilter<MyCustomAttribute>>();

                //// add Security information to each operation for OAuth2
                //c.OperationFilter<SecurityRequirementsOperationFilter>();
                //// or use the generic method, e.g. c.OperationFilter<SecurityRequirementsOperationFilter<MyCustomAttribute>>();

                //// if you're using the SecurityRequirementsOperationFilter, you also need to tell Swashbuckle you're using OAuth2
                //c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                //    In = ParameterLocation.Header,
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey
                //});

            });
            services.AddSwaggerExamplesFromAssemblyOf<ProducerModelExample>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "KafkaProducer API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
