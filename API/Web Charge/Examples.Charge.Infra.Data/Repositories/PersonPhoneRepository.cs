using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync()
        {
            var personPhones = await _context.PersonPhone
                .Include(x => x.Person)
                .Include(x => x.PhoneNumberType)
                .ToListAsync();

            return personPhones;
        }

        public async Task<PersonPhone> Get(int businessEntityID, string phoneNumber, int phoneNumberTypeID)
        {
            var personPhoneInDb = await _context.PersonPhone.FirstOrDefaultAsync(x =>
                x.BusinessEntityID == businessEntityID &&
                x.PhoneNumber == phoneNumber &&
                x.PhoneNumberTypeID == phoneNumberTypeID);

            return personPhoneInDb;
        }

        public async Task<int> Insert(PersonPhone personPhone)
        {
            await _context.PersonPhone.AddAsync(personPhone);
            await _context.SaveChangesAsync();

            return personPhone.BusinessEntityID;
        }

        public async Task Update(PersonPhone personPhoneOld, PersonPhone personPhoneNew)
        {
            var personPhoneInDb = await _context.PersonPhone.FirstOrDefaultAsync(x =>
                x.BusinessEntityID == personPhoneOld.BusinessEntityID &&
                x.PhoneNumber == personPhoneOld.PhoneNumber &&
                x.PhoneNumberTypeID == personPhoneOld.PhoneNumberTypeID);

            _context.Remove(personPhoneInDb);
            await _context.PersonPhone.AddAsync(personPhoneNew);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(PersonPhone personPhone)
        {
            var personPhoneInDb = await _context.PersonPhone.FirstOrDefaultAsync(x =>
                x.BusinessEntityID == personPhone.BusinessEntityID &&
                x.PhoneNumber == personPhone.PhoneNumber &&
                x.PhoneNumberTypeID == personPhone.PhoneNumberTypeID);

            _context.Remove(personPhoneInDb);

            await _context.SaveChangesAsync();
        }
    }
}
