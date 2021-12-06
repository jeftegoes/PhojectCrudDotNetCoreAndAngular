using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Person>> FindAllAsync()
        {
            var persons = await _context.Person.ToListAsync();

            return persons;
        }

        public async Task<Person> Get(int id)
        {
            var person = await _context.Person.FirstOrDefaultAsync(x => x.BusinessEntityID == id);

            return person;
        }

        public async Task<int> Insert(Person person)
        {
            await _context.Person.AddAsync(person);
            await _context.SaveChangesAsync();

            return person.BusinessEntityID;
        }

        public async Task Update(int id, Person person)
        {
            var personInDb = await _context.Person.FirstOrDefaultAsync(x => x.BusinessEntityID == id);

            personInDb.Name = person.Name;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var person = await _context.Person.FirstOrDefaultAsync(x => x.BusinessEntityID == id);

            _context.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
