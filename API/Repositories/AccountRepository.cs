﻿using API.Data;
using API.Models;
using API.Contracts;

namespace API.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BookingManagementDbContext _context;

        public AccountRepository(BookingManagementDbContext context)
        {
            _context = context;
        }
        public Account? Create(Account account)
        {
            try
            {
                _context.Set<Account>().Add(account);
                _context.SaveChanges();
                return account;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(Account account)
        {
            try
            {
                _context.Set<Account>().Remove(account);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Set<Account>().ToList();
        }

        public Account? GetByGuid(Guid guid)
        {
            return _context.Set<Account>().Find(guid);
        }

        public bool Update(Account account)
        {
            try
            {
                _context.Set<Account>().Update(account);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}