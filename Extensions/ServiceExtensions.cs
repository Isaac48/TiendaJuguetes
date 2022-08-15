﻿using Juguetes.Entities;
using Juguetes.Logger;
using Juguetes.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Juguetes.Extensions
{
    public static class ServiceExtensions
	{
		public static void ConfigureCors(this IServiceCollection services) =>
		 services.AddCors(options =>
		 {
			 options.AddPolicy("CorsPolicy", builder =>
			 builder.AllowAnyOrigin()
			 .AllowAnyMethod()
			 .AllowAnyHeader());
		 });

		public static void ConfigureIISIntegration(this IServiceCollection services) =>
			services.Configure<IISOptions>(options =>
			{
			});
		public static void ConfigureLoggerService(this IServiceCollection services) =>
		services.AddScoped<ILoggerManager, LoggerManager>();

		public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,
			IConfiguration configuration) =>
				services.AddDbContext<ApplicationContext>(opts =>
					opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
						b.MigrationsAssembly("Juguetes")));
	}
}
