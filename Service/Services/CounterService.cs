﻿using Dnsk.Db;
using Dnsk.Proto;
using Dnsk.Service.Util;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Dnsk.Service.Services;

public class CounterService : Counter.CounterBase
{
    private static uint _count = 0;
    private readonly ILogger<CounterService> _logger;
    private readonly DnskDb _db;
    private readonly ISessionManager _session;
    
    public CounterService(ILogger<CounterService> logger, DnskDb db, ISessionManager session)
    {
        _logger = logger;
        _db = db;
        _session = session;
    }

    public override async  Task<CountReply> Count(CountRequest req, ServerCallContext stx)
    {
        _logger.LogError("counting...");
        // await _db.Auths.AddAsync(new Auth()
        // {
        //     Id = Ulid.NewUlid()
        // });
        // await _db.SaveChangesAsync();
        var ses = _session.Get(stx);
        
        return new CountReply
        {
            Count = (uint)_count++
        };
    }
}