using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WeatherStatistics.Models
{
    public class LoadFileModel
    {
        [Required]
        [FileType(".xlsx")]
        public IEnumerable<IFormFile> Files { get; set; }
    }

    public class FileTypeAttribute : ValidationAttribute
    {
        private string[] _allowedTypes {  get; set; }
        public FileTypeAttribute(params string[] allowedTypes)
        {
            _allowedTypes = allowedTypes;
        }
        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            IEnumerable<IFormFile> files = value as IEnumerable<IFormFile>;
            foreach(var file in files)
            {
                if (!_allowedTypes.Contains(Path.GetExtension(file.FileName)))
                {
                    return new ValidationResult($"File {file.FileName} has not a valid file type, allowed types: {string.Join(" ",_allowedTypes)}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
