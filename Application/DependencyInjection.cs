using Application.DTO;
using Application.DTO.Candidate;
using Application.DTO.Recruiter;
using Application.Interfaces;
using Application.Producers.RegisterProducer;
using Application.Services;
using Application.Services.ServiceHelpers;
using Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Czytanie automappera z całego assembly
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutomapperConfiguration)));

            //Dodawanie walidatorów do kontenera DI
            services.AddScoped<IValidator<BaseDTO>, RegisterRequestValidator>();
            services.AddScoped<IValidator<CandidateRegisterRequestDTO>, CandidateRegisterRequestValidator>();
            services.AddScoped<IValidator<RecruiterRegisterRequestDTO>, RecruiterRegisterRequestValidator>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<RegisterHelper>();

            return services;
        }
    }
}
