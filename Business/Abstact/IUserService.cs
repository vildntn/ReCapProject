using Core.Entities.Concreate;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstact
{
    public interface IUserService
    {

        IDataResult<List<User>> GetAll();

        IDataResult<User> GetById(int id);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<OperationClaim>> GetClaims(User user);

        IDataResult<User> GetByMails(string email);
        User GetByMail(string email);

    }
}
