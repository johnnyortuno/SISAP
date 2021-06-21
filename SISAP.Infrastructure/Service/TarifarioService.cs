using SISAP.Core.Entities;
using SISAP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Infrastructure.Service
{
	public class TarifarioService : _BaseContext, ITarifarioService
	{
		public IEnumerable<Tarifario> getTarifario()
		{
			using (var dbContext = GetSISAPDBContext())
			{
				return dbContext.Tarifarios.OrderBy(t => t.TarifarioId).ToList();
			}
		}
	}
}
