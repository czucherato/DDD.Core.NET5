using FluentValidation.Results;
using System.Collections.Generic;

namespace DDD.Core.NET5.Common.Specification.Validation
{
    public class SpecValidator<T>
    {
        private readonly Dictionary<string, Rule<T>> _validations = new();

        public ValidationResult Validate(T obj)
        {
            var validationResult = new ValidationResult();
            foreach (var rule in _validations.Keys)
            {
                var validation = _validations[rule];
                if (!validation.Validate(obj))
                    validationResult.Errors.Add(new ValidationFailure(obj.GetType().Name, validation.ErrorMessage));
            }

            return validationResult;
        }

        public void Add(string name, Rule<T> rule)
        {
            _validations.Add(name, rule);
        }

        public void Remove(string name)
        {
            _validations.Remove(name);
        }

        public Rule<T> GetRule(string name)
        {
            _validations.TryGetValue(name, out var rule);
            return rule;
        }
    }
}