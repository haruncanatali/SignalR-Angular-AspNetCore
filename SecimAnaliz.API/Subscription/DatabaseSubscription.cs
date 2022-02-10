using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using SecimAnaliz.API.Hubs;
using SecimAnaliz.API.Models;
using TableDependency.SqlClient;

namespace SecimAnaliz.API.Subscription
{
    public interface IDatabaseSubscription
    {
        void Configure(string tableName);
    }

    public class DatabaseSubscription<T> : IDatabaseSubscription where T : class, new()
    {
        private SqlTableDependency<T> _tableDependency;
        private IConfiguration _configuration;
        private IHubContext<OyHub> _hubContext;

        public DatabaseSubscription(IConfiguration x, IHubContext<OyHub> y)
        {
            this._configuration = x;
            this._hubContext = y;
        }

        public void Configure(string tableName)
        {
            _tableDependency =
                new SqlTableDependency<T>(_configuration.GetConnectionString("DefaultConnection"), tableName);

            _tableDependency.OnChanged += async (o, e) =>
            {
                DboSecimAnalizContext context = new DboSecimAnalizContext();
                List<OyDto> dagilim = new List<OyDto>();

                var partiler = context.TblPartis.ToList();
                var oylar = context.TblOys.ToList();
                foreach (var item in partiler)
                {
                    dagilim.Add(new OyDto
                    {
                        label = item.PartiAdi,
                        value = oylar.Where(c=>c.PartiId == item.Id).ToList().Count()
                    });
                }

                await _hubContext.Clients.All.SendAsync("receiveMessage", dagilim);

            };

            _tableDependency.OnError += (o, e) =>
            {

            };

            _tableDependency.Start();
        }

        ~DatabaseSubscription()
        {
            _tableDependency.Stop();
        }
    }
}
