using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _300954759_Kim__300825160_Perroni__GroupProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace _300954759_Kim__300825160_Perroni__GroupProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // This line gets the configuration of AWS profile in the appsetting.json file

            // var options = Configuration.GetAWSOptions();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc( options => {
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", "application/json");
            }).AddXmlSerializerFormatters();

            // register swagger generator
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "My first API", Version = "v1" });
            });

            // This line adds the DbContext and uses the connection string stored in the appsettings.json file
            services.AddDbContext<heeyeong_kenny_group_projectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connectionToRDS")));
            // This line adds the default AWS options as per configuration
            // services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // Enable middleware to serve generated swagger as a json endpoint
            app.UseSwagger();

            // Specify the swagger json endpoint
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My first API");
            });
        }
    }
}
