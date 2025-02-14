using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using RRSolucoesFinanceiraUsers.Infra.Data.Context;
using System;

namespace RRSolucoesFinanceiraUsers.Infra.Data.Repository;

public class UnityOfWork<T> : IUnityOfWork<T> where T : class
{
    private IAddressEntityRepository? _addressRepository;
    private IDocumentEntityRepository? _documentRepository;
    private IPhoneEntityRepository? _phoneRepository;
    private IUserEntityRepository? _userRepository;
    private IUserEntityRolesRepository _userRolesRepository;
    private IRepository<T> _repository;
    public ApplicationDBContext _context;

    public UnityOfWork(ApplicationDBContext context)
    {
        _context = context;
    }

    public IAddressEntityRepository AddressEntityRepository
    {
        get
        {
            return _addressRepository = _addressRepository ?? new AddressEntityRepository(_context);
        }
    }

    public IDocumentEntityRepository DocumentEntityRepository
    {
        get
        {
            return _documentRepository = _documentRepository ?? new DocumentEntityRepository(_context);
        }
    }

    public IPhoneEntityRepository PhoneEntityRepository
    {
        get 
        {
            return _phoneRepository = _phoneRepository ?? new PhoneEntityRepository(_context);   

        }
    }

    public IUserEntityRepository UserEntityRepository
    {
        get
        {
            return _userRepository = _userRepository ?? new UserEntityRepository(_context);
        }
    }

    public IUserEntityRolesRepository UserEntityRolesRepository
    {
        get
        {
            return _userRolesRepository = _userRolesRepository ?? new UserEntityRolesRepository(_context);
        }
    }

    public IRepository<T> Repository
    {
        get
        {
            return _repository = _repository ?? new Repository<T>(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
