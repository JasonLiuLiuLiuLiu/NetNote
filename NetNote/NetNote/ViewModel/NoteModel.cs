using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NetNote.Models;

namespace NetNote.ViewModel
{
    public class NoteModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "标题")]
        [MaxLength(1000)]
        public string Tile { get; set; }
        [Required]
        [Display(Name = "内容")]
        public string Content { get; set; }

        [Display(Name = "类型")]
        public int Type { get; set; }
    }
}
