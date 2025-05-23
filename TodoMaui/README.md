# ToDo List با .NET MAUI

این پروژه یک اپلیکیشن ToDo List ساده است که با استفاده از .NET MAUI و معماری MVVM پیاده‌سازی شده است.

## ویژگی‌ها

- افزودن کار جدید
- نمایش لیست کارها
- علامت‌گذاری کارهای انجام‌شده
- حذف کار
- ویرایش کار
- ذخیره‌سازی لوکال (با SQLite)
- رابط کاربری فارسی و راست‌چین

## تکنولوژی‌ها

- **پلتفرم:** .NET MAUI
- **زبان:** C#
- **ذخیره‌سازی:** SQLite (با SQLite-net)
- **معماری:** MVVM

## ساختار پروژه

```
/ToDoApp
├── Models          # کلاس TaskItem
├── ViewModels      # کلاس MainViewModel
├── Views           # صفحه MainPage.xaml
├── Services        # SQLiteService
├── Resources       # استایل، فونت فارسی
├── App.xaml
└── MainPage.xaml
```

## نحوه اجرا

1. پروژه را کلون کنید.
2. پکیج‌های مورد نیاز را نصب کنید:
   ```bash
   dotnet restore
   ```
3. پروژه را بیلد کنید:
   ```bash
   dotnet build
   ```
4. برنامه را اجرا کنید:
   ```bash
   dotnet run
   ```

## نکات

- از SQLite برای ذخیره‌سازی داده‌ها استفاده می‌شود.
- رابط کاربری به صورت راست‌چین و فارسی پیاده‌سازی شده است.
- از معماری MVVM برای جداسازی منطق برنامه از رابط کاربری استفاده شده است.

## مشارکت

اگر مایل به مشارکت در این پروژه هستید، لطفاً یک Pull Request ارسال کنید.

## توسعه‌دهنده

- **نام:** مختار سهولی
- **GitHub:** [codina1](https://github.com/codina1)
- **ایمیل:** soholi.info@gmail.com
- **تلفن:** 09150904936 