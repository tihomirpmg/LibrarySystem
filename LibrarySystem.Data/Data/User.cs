using System.ComponentModel.DataAnnotations;

namespace DataAcess.Data.Models
{
    /// <summary>
    /// User model class
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// User Id property
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// User Username property
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// User Password property
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// User Roles property
        /// </summary>
        [Required]
        public string Roles { get; set; }

        /// <summary>
        /// User E-mail property
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// User Names property
        /// </summary>
        [Required]
        public string Names { get; set; }
    }
}
