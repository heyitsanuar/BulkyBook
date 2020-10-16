using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		ISP_Call SP_Call { get; }
		SongRepository Song { get; }
	}
}
