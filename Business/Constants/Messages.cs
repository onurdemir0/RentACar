using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string CarAdded = "Araç başarıyla eklendi!";
		public static string CarDeleted = "Araç başarıyla silindi!";
		public static string CarUpdated = "Araç başarıyla güncellendi!";
		public static string CarPriceInvalid = "Araç fiyatı 0'dan büyük olmalıdır.";
		public static string CarsListed = "Araçlar Listelendi";

		public static string BrandAdded = "Marka başarıyla eklendi!";
		public static string BrandDeleted = "Marka başarıyla silindi!";
		public static string BrandUpdated = "Marka başarıyla güncellendi!";
		public static string BrandNameInvalid = "Marka isim uzunluğu 2'den büyük olmalıdır!";

		public static string ColorAdded = "Renk başarıyla eklendi!";
		public static string ColorDeleted = "Renk başarıyla silindi!";
		public static string ColorUpdated = "Renk başarıyla güncellendi!";

		public static string UserAdded = "Kullanıcı başarıyla eklendi!";
		public static string UserDeleted = "Kullanıcı başarıyla silindi!";
		public static string UserUpdated = "Kullanıcı başarıyla güncellendi!";

		public static string CustomerAdded = "Müşteri başarıyla eklendi!";
		public static string CustomerDeleted = "Müşteri başarıyla silindi!";
		public static string CustomerUpdated = "Müşteri başarıyla güncellendi!";

		public static string RentalAdded = "Kiralama başarıyla eklendi!";
		public static string RentalDeleted = "Kiralama başarıyla silindi!";
		public static string RentalUpdated = "Kiralama başarıyla güncellendi!";
		public static string CarAlreadyRented = "Bu araç zaten kiralanmış!";

		public static string MaintenanTime = "Sistem bakımda";

		public static string AuthorizationDenied = "Yetkilendirme Reddedildi";
		public static string UserNotFound = "Kullanıcı bulunamadı";
		public static string UserAlreadyExists = "Kullanıcı mevcut";
		public static string SuccessfulLogin = "Giriş başarılı";
		public static string UserRegistered = "Kullanıcı oluşturuldu";
		public static string PasswordError = "Şifre hatalı";
		public static string AccessTokenCreated = "Erişim belirtici oluşturuldu";
	}
}
