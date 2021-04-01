using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IFakeCardService
	{
        IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber);
        IDataResult<List<FakeCard>> GetAll();
        IDataResult<FakeCard> GetById(int cardId);
        IResult IsCardExist(FakeCard fakeCard);
        IResult Add(FakeCard fakeCard);
        IResult Delete(FakeCard fakeCard);
        IResult Update(FakeCard fakeCard);
    }
}
