using AutoMapper;
using Examples.Charge.Application.AutoMapper;
using Examples.Charge.Application.Facade;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Domain.Aggregates.PersonPhoneAggregate;
using Examples.Charge.Domain.Aggregates.PhoneNumberTypeAggregate;
using Examples.Charge.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Examples.Charge.Infra.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void Setup(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterAutoMapper(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IExampleService, ExampleService>();
            services.AddScoped<IExampleRepository, ExampleRepository>();

            services.AddScoped<IPersonFacade, PersonFacade>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<IPersonPhoneFacade, PersonPhoneFacade>();
            services.AddScoped<IPersonPhoneService, PersonPhoneService>();
            services.AddScoped<IPersonPhoneRepository, PersonPhoneRepository>();

            services.AddScoped<IPhoneNumberTypeFacade, PhoneNumberTypeFacade>();
            services.AddScoped<IPhoneNumberTypeService, PhoneNumberTypeService>();
            services.AddScoped<IPhoneNumberTypeRepository, PhoneNumberTypeRepository>();
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<PersonProfile>();
                configuration.AddProfile<PhoneNumberTypeProfile>();
                configuration.AddProfile<PersonPhoneProfile>();
            }).CompileMappings();
        }
    }
}