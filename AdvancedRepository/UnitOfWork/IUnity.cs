using AdvancedRepository.Repository.Interfaces;

namespace AdvancedRepository.UnitOfWork
{
    public interface IUnity
    {
        ICategoryRepository _catRepos { get; } //Sadece get çünkü sadece okunacak
        ICityRepository _cityRepos { get; } //Ne kadar repository varsa hepsi tanımlanır.
        ICountyRepository _countyRepos { get; }
        ICustomerRepository _customerRepos { get; }
        IEmployeeRepository _empRepos { get; }
        IProductRepository _proRepos { get; }
        ISupplierRepository _supRepos { get; }
        IUnitRepository _unitRepos { get; }
        IFatMasterRepository _fatRepos { get; }
        IFatDetailRepository _fatdetailRepos { get; }
        IAuthRepository _authRepository { get; }
        IBasketDetailRepository _basketDetailRepository { get; }
        IBasketMasterRepository _basketMasterRepository { get; }      
        void Commit(); //savechanges
        void Dispose(); //Memory'i temizlemek için
    }
}
