namespace RISE.Utils.FluentValidationExtensions
{
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Reflection;

    public class FluentValidationExtensions<T> where T : class
    {
        public static void RegisterFluentValidation(IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            RegisterValidators(services);
        }

        private static void RegisterValidators(IServiceCollection services)
        {
            var assembly = typeof(T).GetTypeInfo().Assembly;
            var validatorType = typeof(IValidator);

            var validators = assembly
                .GetExportedTypes()
                .Where(e => validatorType.IsAssignableFrom(e) && !e.IsInterface);

            foreach (var validator in validators)
            {
                services.AddTransient(validator);

                var validatorInterfaces = validator
                    .GetInterfaces()
                    .Where(e => e.IsGenericType && e.GetGenericTypeDefinition() == typeof(IValidator<>));

                foreach (var validatorInterface in validatorInterfaces)
                    services.AddTransient(validatorInterface, validator);
            }
        }
    }
}