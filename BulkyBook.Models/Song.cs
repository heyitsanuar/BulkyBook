using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BulkyBook.Models
{
	public class Song
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string Title { get; set; }
		[Required]
		[MaxLength(50)]
		public string Author { get; set; }
		[Range(1,5)]
		public int Rating { get; set; }

	}
}
