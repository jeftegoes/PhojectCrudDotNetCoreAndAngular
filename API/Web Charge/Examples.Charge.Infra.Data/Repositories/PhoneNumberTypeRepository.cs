using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PhoneNumberTypeRepository : IPhoneNumberTypeRepository
    {
        private readonly ExampleContext _context;

        public PhoneNumberTypeRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PhoneNumberType>> FindAllAsync()
        {
            var phoneNumberTypes = _context.PhoneNumberType.ToListAsync();

            return await phoneNumberTypes;
        }

        public async Task<PhoneNumberType> Get(int id)
        {
            var phoneNumberType = await _context.PhoneNumberType.FirstOrDefaultAsync(x => x.PhoneNumberTypeID == id);

            return phoneNumberType;
        }

        public async Task<int> Insert(PhoneNumberType phoneNumberType)
        {
            await _context.PhoneNumberType.AddAsync(phoneNumberType);
            await _context.SaveChangesAsync();

            return phoneNumberType.PhoneNumberTypeID;
        }

        public async Task Update(int id, PhoneNumberType phoneNumberType)
        {
            var phoneNumberTypeInDb = await _context.PhoneNumberType.FirstOrDefaultAsync(x => x.PhoneNumberTypeID == id);

            phoneNumberTypeInDb.Name = phoneNumberType.Name;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var phoneNumberType = await _context.PhoneNumberType.FirstOrDefaultAsync(x => x.PhoneNumberTypeID == id);

            _context.Remove(phoneNumberType);

            await _context.SaveChangesAsync();
        }
    }
}
