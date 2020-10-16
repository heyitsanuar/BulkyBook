using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
	public interface ISongRepository : IRepository<SongRepository>
	{
		void Update(Song song);
	}
}
