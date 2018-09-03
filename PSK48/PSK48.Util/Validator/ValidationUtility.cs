using PSK48.Util.Validator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PSK48.Util.Validator
{
    public class ValidationUtility<T>
    {
        private readonly List<ValidationRule<T>> _predicatFactory;
        private readonly T _baseModel;

        public ValidationUtility(T baseModel)
        {
            _predicatFactory = new List<ValidationRule<T>>();
            _baseModel = baseModel;
        }

        public void AddRule(Expression<Func<T, bool>> predicate, string errorMessage, int sequence = 1)
        {
            var compliePredicate = predicate.Compile();
            _predicatFactory.Add(new ValidationRule<T>()
            {
                Prediction = compliePredicate,
                ErrorMessage = errorMessage,
                Sequence = sequence
            });
        }

        public void AddCustomAction(Func<T, bool> validateAction, string errorMessage, int sequence = 1)
        {
            _predicatFactory.Add(new ValidationRule<T>()
            {
                Prediction = validateAction,
                ErrorMessage = errorMessage,
                Sequence = sequence
            });
        }

        public IEnumerable<string> Validate()
        {
            var errorList = new List<string>();
            var maxSequence = _predicatFactory.OrderByDescending(x => x.Sequence).FirstOrDefault()?.Sequence;
            var minSequence = _predicatFactory.OrderBy(x => x.Sequence).FirstOrDefault()?.Sequence;
            var correctSequence = minSequence;

            if (!correctSequence.HasValue)
                throw new ArgumentException("Cannot get correctSequence, please check your source code.");

            while (correctSequence <= maxSequence)
            {
                var correntSeq = correctSequence;

                if (errorList.Any())
                    return errorList;

                var predicateInSeq = _predicatFactory.Where(x => x.Sequence == correntSeq).ToList();
                var nextSeq = _predicatFactory.Where(x => x.Sequence > correntSeq).OrderBy(x => x.Sequence)
                    .FirstOrDefault()?.Sequence;

                predicateInSeq.ForEach(predicate =>
                {
                    if (predicate.Prediction?.Invoke(_baseModel) == true)
                        errorList.Add(predicate.ErrorMessage);
                });

                if (nextSeq.HasValue)
                    correctSequence = nextSeq;
                else
                    correctSequence = correctSequence + 1;
            }
            return errorList;
        }
    }
}
