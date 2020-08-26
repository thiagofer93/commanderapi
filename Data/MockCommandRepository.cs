using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommandRepository : ICommandRepository
    {
        public void Create(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAll()
        {
            return new List<Command> {
                new Command {
                Id = 1,
                HowTo = "All we hear is",
                Line = "Radio gaga",
                Platform = "Radio gogo"
                },
                new Command {
                    Id = 2,
                    HowTo = "Mamaaaa",
                    Line = "Just killed a man",
                    Platform = "Put a gun against his head"
                }
            };
        }

        public Command GetById(int id)
        {
            return new Command
            {
                Id = 1,
                HowTo = "All we hear is",
                Line = "Radio gaga",
                Platform = "Radio gogo"
            };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}