using System.ComponentModel.DataAnnotations;

namespace DataAcess.Data.Models;

/// <summary>
/// LibraryBook model class
/// </summary>
public partial class LibraryBook
{
    /// <summary>
    /// LibraryBook Id property
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// LibraryBook Name property
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// LibraryBook Condition property
    /// </summary>
    [Required]
    public string Condition { get; set; }

    /// <summary>
    /// LibraryBook Bearer property
    /// </summary>
    [Required]
    public string Bearer { get; set; }

    /// <summary>
    /// LibraryBook Stock property
    /// </summary>
    [Required]
    public string Stock { get; set; }
}
