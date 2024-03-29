﻿using System.ComponentModel.DataAnnotations;

namespace DataAcess.Data.Models;

/// <summary>
/// Section model class
/// </summary>
public partial class Section
{
    /// <summary>
    /// Section Id property
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Section Name property
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Section Book property
    /// </summary>
    [Required]
    public string Book { get; set; }

    /// <summary>
    /// Section Description property
    /// </summary>
    [Required]
    public string Description { get; set; }
}
