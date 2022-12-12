#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace RichSessionWorkshop.Models;

public class NameInput
{
    [Required(ErrorMessage = "Name is required.")]
    public string Username { get; set; }
    public int Count { get; set; }
}