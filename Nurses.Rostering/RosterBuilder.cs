# pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Collections;
using Nurses.Rostering.Models;
using Microsoft.Extensions.Logging;

namespace Nurses.Rostering
{
    public class RosterBuilder
    {
      protected readonly ILogger _logger;
      protected readonly IShiftsProvider _shiftsProvider;
      protected readonly ISchedulesProvider _schedulesProvider;
      protected readonly INursesProvider _nursesProvider;
      protected readonly IPickupService _pickupService;
      protected readonly IRosterProvider _rosterProvider;

        public RosterBuilder()
        {
          // Todo: should use default DI logger
          _logger = null;
          _shiftsProvider = new ShiftsProvider(_logger);
          _schedulesProvider = new SchedulesProvider(_logger, _shiftsProvider);
          _nursesProvider = new NursesProvider(_logger);
          _pickupService = new RandamPickupService(_logger);
          _rosterProvider = new RosterProvider(_logger, _schedulesProvider, _nursesProvider, _shiftsProvider, _pickupService);

          _shiftsProvider.Add(new Shift("Morning"));
          _shiftsProvider.Add(new Shift("Evening"));
          _shiftsProvider.Add(new Shift("Night"));
        }

        public Roster Build(DateTime start, DateTime end, List<Nurse> nurses)
        {
          _schedulesProvider.Initialise(start, end);
          nurses.ForEach(nurse => _nursesProvider.Enroll(nurse));

          var roster = new Roster();
          roster.Jobs = _rosterProvider.Generate();
          return roster;
        }
    }
}