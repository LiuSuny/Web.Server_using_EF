

using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkBasic
{
    /// <summary>
    /// Our setting database table representational model
    /// </summary>
    public class SettingsDataModel
    {
        /// <summary>
        /// The unique id for this entry
        /// </summary>
        [Key]
        public string Id  { get; set; }

        /// <summary>
        /// the settings name 
        /// [required] mean our name must not null value
        /// [MaxLength, MinLength] name can take
        /// </summary>
        [Required] 
        [MinLength(3), MaxLength(256)]
        public string  Name { get; set; }

        /// <summary>
        /// the settings value 
        /// [required] mean our name must not null value
        /// </summary>
        [Required]  
        [MinLength(3), MaxLength(2048)]
        public string Value  { get; set; }
    }
}
