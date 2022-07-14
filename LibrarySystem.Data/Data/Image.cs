using System.ComponentModel.DataAnnotations.Schema;
using DataAcess.Data.Models;

namespace LibrarySystem.Data.Data;

/// <summary>
/// Images model class
/// </summary>
public class Image
{
    /// <summary>
    /// Images Id property
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Images BookId property
    /// </summary>
    public int BookId { get; set; }

    /// <summary>
    /// Images BookImageUrl property
    /// </summary>
    public string BookImageUrl { get; set; }

    /// <summary>
    /// Images virtual Title property
    /// </summary>
    [ForeignKey("BookId")]
    public virtual Title Title { get; set; }
}
