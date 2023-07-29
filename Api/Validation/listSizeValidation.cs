using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Api.Validation
{
    public class ListSizeValidation : ValidationAttribute
    {
        private readonly int _size = 0;

        public ListSizeValidation(int size) 
        {
            _size = size;
        }

        public override bool IsValid(object? value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count == _size;
            }
            return false;
        }
    }
}
