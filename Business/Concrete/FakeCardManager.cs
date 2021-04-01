using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class FakeCardManager : IFakeCardService
	{
		private IFakeCardDal _fakeCardDal;

		public FakeCardManager(IFakeCardDal fakeCarDal)
		{
			_fakeCardDal = fakeCarDal;
		}

		public IResult Add(FakeCard fakeCard)
		{
			_fakeCardDal.Add(fakeCard);
			return new SuccessResult();
		}

		public IResult Delete(FakeCard fakeCard)
		{
			_fakeCardDal.Delete(fakeCard);
			return new SuccessResult();
		}

		public IDataResult<List<FakeCard>> GetAll()
		{
			return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll());
		}

		public IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber)
		{
			return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll(c => c.CardNumber == cardNumber));
		}

		public IDataResult<FakeCard> GetById(int cardId)
		{
			return new SuccessDataResult<FakeCard>(_fakeCardDal.Get(c => c.Id == cardId));
		}

		public IResult IsCardExist(FakeCard fakeCard)
		{
			var result = _fakeCardDal.Get(c => c.NameOnTheCard == fakeCard.NameOnTheCard && c.CardNumber == fakeCard.CardNumber && c.CardCvv == fakeCard.CardCvv);
			if (result == null)
			{
				return new ErrorResult();
			}
			return new SuccessResult();
		}

		public IResult Update(FakeCard fakeCard)
		{
			_fakeCardDal.Update(fakeCard);
			return new SuccessResult();
		}
	}
}
