using System.ComponentModel.DataAnnotations;

namespace Api.Validation
{
    public class ListItemSize : ValidationAttribute
    {
        private readonly int _maxLength;
        public ListItemSize(int maxLength) 
        {
            _maxLength = maxLength;
        }

        public override bool IsValid(object? value)
        {
            var listItems = value as IList<string>;
            if (listItems != null)
            {
                return listItems.All(x => x.Length <= _maxLength);
            }
            return false;
        }
    }
}
