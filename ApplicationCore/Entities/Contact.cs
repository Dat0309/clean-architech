using ApplicationCore.Constants;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public partial class Contact : IValidatableObject
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Subject { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;

    public string? Phone { get; set; }
    [Required]
    public string Description { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Name.Length > ContentManager.ValidationNameLength)
        {
            yield return new ValidationResult(ContentManager.ValidationNameMSG);
        }else if(Subject.Length > ContentManager.ValidationSubjectLength)
        {
            yield return new ValidationResult(ContentManager.ValidationSubjectMSG);
        }else if(Description.Length > ContentManager.ValidationDescLength)
        {
            yield return new ValidationResult(ContentManager.ValidationDescMSG);
        }else if(Email.Length > ContentManager.ValidationEmailLength)
        {
            yield return new ValidationResult(ContentManager.ValidationEmailMSG);
        }else if(Phone!.Length > ContentManager.ValidationPhoneLength)
        {
            yield return new ValidationResult(ContentManager.ValidationPhoneMSG);
        }
    }
}
