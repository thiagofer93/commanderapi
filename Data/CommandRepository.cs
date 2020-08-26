using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class CommandRepository : ICommandRepository
    {
        private readonly CommanderContext _db;
        public CommandRepository(CommanderContext db)
        {
            _db = db;
        }

        public void Create(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            _db.Commands.Add(command);
        }

        public void Delete(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            _db.Commands.Remove(command);
        }

        public IEnumerable<Command> GetAll()
        {
            return _db.Commands;
        }

        public Command GetById(int id)
        {
            return _db.Commands.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return _db.SaveChanges() >= 0;
        }

        public void Update(Command command)
        {

        }
    }
}