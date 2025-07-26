using FesteroApp.Domain.Interfaces.Companies;
using FesteroApp.Domain.Interfaces.Users;
using FesteroApp.Domain.Securities;
using FesteroApp.SharedKernel.Securities;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Users.LoginUser;

public class LoginUserHandler : ICommandHandler<LoginUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWorkFactory _unitOfWork;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly ITenantContext _tenantContext;

    public LoginUserHandler(IUserRepository userRepository, ICompanyRepository companyRepository,
        IUnitOfWorkFactory unitOfWork, ITokenGenerator tokenGenerator, ITenantContext tenantContext)
    {
        Throw.ArgumentIsNull(userRepository);
        Throw.ArgumentIsNull(companyRepository);
        Throw.ArgumentIsNull(unitOfWork);
        Throw.ArgumentIsNull(tokenGenerator);
        Throw.ArgumentIsNull(tenantContext);

        _userRepository = userRepository;
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _tokenGenerator = tokenGenerator;
        _tenantContext = tenantContext;
    }

    public async Task HandleAsync(LoginUserCommand command)
    {
        using var scope = _unitOfWork.Get(true);
        
        Throw.IsFalse(await _userRepository.IsCredentialsValid(command.Email!, command.Password), "User.Login",
            "Usuário e/ou senha incorretas.");

        var user = await _userRepository.GetAsyncByEmail(command.Email!);
        var token = _tokenGenerator.Generate(user, user.Companies.ToList());

        command.Token = token;
        
        scope.Complete();
    }
}