﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Migrations
{
    public class Worker:IHostedService
    {
        private readonly ApplicationDataContext _context;
        public Worker(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _context.Database.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
