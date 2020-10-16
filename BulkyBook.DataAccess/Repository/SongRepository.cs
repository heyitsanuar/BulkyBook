using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
	public class SongRepository : Repository<Song>, ISongRepository
	{
		private readonly ApplicationDbContext _db;
		public SongRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Add(SongRepository entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<SongRepository> GetAll(Expression<Func<SongRepository, bool>> filter = null, Func<IQueryable<SongRepository>, IOrderedQueryable<SongRepository>> orderBy = null, string includeProperties = null)
		{
			throw new NotImplementedException();
		}

		public SongRepository GetFirstOrDefault(Expression<Func<SongRepository, bool>> filter = null, string includeProperties = null)
		{
			throw new NotImplementedException();
		}

		public void Remove(SongRepository entity)
		{
			throw new NotImplementedException();
		}

		public void RemoveRange(IEnumerable<SongRepository> entity)
		{
			throw new NotImplementedException();
		}

		public void Update(Song song)
		{
			var obj = _db.Songs.FirstOrDefault(s => s.Id == song.Id);

			if(song != null)
			{
				obj.Title = song.Title;
				obj.Author = song.Author;
				obj.Rating = song.Rating;
			}
		}

		SongRepository IRepository<SongRepository>.Get(int id)
		{
			throw new NotImplementedException();
		}
	}
}
