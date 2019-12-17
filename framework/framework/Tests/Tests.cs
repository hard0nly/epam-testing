using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using TestAutomation.Pages;
using TestAutomation.Service;
using TestAutomation.Utils;
using TestAutomation.Models;
using TestAutomation.Logging;

namespace TestAutomation
{
    [TestFixture]
    public class Tests : CommonConditions
    {
        [Test]
        public void BookCarForZeroDays()
        {
            Logger.Log.Info("Start BookCarForZeroDays test.");

            HomePage homePage = new HomePage(Driver)
                .ChooseBusinessClass();

            BusinessClass businessClass = new BusinessClass(Driver)
                .SelectFirstBusinessCar();

            CarBooking carBooking = new CarBooking(Driver)
                .ClickOrderButton();

            Assert.AreEqual(WarningsAndLetterings.EnterCorrectDays, carBooking.GetAlertText());
        }

        [Test]
        public void SendEmptyReview()
        {
            Logger.Log.Info("Start SendEmptyReview test.");

            HomePage homePage = new HomePage(Driver)
                .ClickReviewTab();

            Reviews reviews = new Reviews(Driver)
                .SendReview();

            Assert.AreEqual(WarningsAndLetterings.SelectRating, reviews.GetDangerMessageText());
        }

        [Test]
        public void BookCarWithEmptyInfo()
        {
            Logger.Log.Info("Start BookCarWithEmptyInfo test.");

            HomePage homePage = new HomePage(Driver)
                .ChooseBusinessClass();

            BusinessClass businessClass = new BusinessClass(Driver)
                .SelectFirstBusinessCar();

            CarBooking carBooking = new CarBooking(Driver)
                .InputDaysQuantity(RandomGenerator.GetRandomDaysQuantity())
                .ClickOrderButton()
                .GoToCheckout();

            Checkout checkout = new Checkout(Driver)
                .SubmitCheckout();

            Assert.AreNotEqual(String.Empty, checkout.GetErrorMessage());
        }

        [Test]
        public void BookCarWithWrongInfo()
        {
            Logger.Log.Info("Start BookCarWithWrongInfo test.");

            HomePage homePage = new HomePage(Driver)
                .ChooseBusinessClass();

            BusinessClass businessClass = new BusinessClass(Driver)
                .SelectFirstBusinessCar();

            CarBooking carBooking = new CarBooking(Driver)
                .InputDaysQuantity(RandomGenerator.GetRandomDaysQuantity())
                .ClickOrderButton()
                .GoToCheckout();

            Checkout checkout = new Checkout(Driver)
                .WriteBookingInfo(BookingInfoCreater.WrongBookingInfo())
                .SubmitCheckout();

            Assert.IsTrue((new Regex(@"(\w*)success")).IsMatch(Driver.Url));
        }

        [Test]
        public void CountNumberOfServices()
        {
            Logger.Log.Info("Start CountNumberOfServices test.");

            HomePage homePage = new HomePage(Driver)
                .ChooseBusinessClass();

            BusinessClass businessClass = new BusinessClass(Driver)
                .SelectFirstBusinessCar();

            CarBooking carBooking = new CarBooking(Driver)
                .InputDaysQuantity(RandomGenerator.GetRandomDaysQuantity())
                .ClickOrderButton();

            Assert.AreNotEqual(WarningsAndLetterings.TotalOfEmptyCart, carBooking.GetCartTotalText());
        }

        [Test]
        public void BookCarAndCancelBooking()
        {
            Logger.Log.Info("Start BookCarAndCancelBooking test.");

            HomePage homePage = new HomePage(Driver)
                .ChooseBusinessClass();

            BusinessClass businessClass = new BusinessClass(Driver)
                .SelectFirstBusinessCar();

            CarBooking carBooking = new CarBooking(Driver)
                .InputDaysQuantity(RandomGenerator.GetRandomDaysQuantity())
                .ClickOrderButton()
                .OpenCartPreview()
                .RemoveBooking();

            Assert.AreEqual(WarningsAndLetterings.TotalOfEmptyCart, carBooking.GetCartTotalText());
        }

        [Test]
        public void TranslateToOtherLanguage()
        {
            Logger.Log.Info("Start TranslateToOtherLanguage test.");

            HomePage homePage = new HomePage(Driver)
                .ChangeToEnglishLanguage();

            Assert.AreEqual(WarningsAndLetterings.EnglishTextOfReviewTab, homePage.GetReviewTabText());
        }

        [Test]
        public void SendEmptyMessageToAdministration()
        {
            Logger.Log.Info("Start SendEmptyMessageToAdministration test.");

            HomePage homePage = new HomePage(Driver)
                .ClickContactsTab();

            Contacts contacts = new Contacts(Driver)
                .SendMessage();

            Assert.AreEqual(WarningsAndLetterings.EnterCorrectName, contacts.GetDangerMessage());
        }

        [Test]
        public void SortAutoByPrice()
        {
            Logger.Log.Info("Start SortAutoByPrice test.");

            HomePage homePage = new HomePage(Driver)
                .ChooseBusinessClass();

            BusinessClass businessClass = new BusinessClass(Driver);
            string firstBusinessCarPriceBefore = businessClass.GetFirstBusinessCarPriceText();
            businessClass = businessClass.SelectSortByPriceFromBiggerToSmaller();

            Assert.AreNotEqual(firstBusinessCarPriceBefore, businessClass.GetFirstBusinessCarPriceText());
        }

        [Test]
        public void BookCarWithRightInfo()
        {
            Logger.Log.Info("Start BookCarWithRightInfo test.");

            HomePage homePage = new HomePage(Driver)
                .ChooseBusinessClass();

            BusinessClass businessClass = new BusinessClass(Driver)
                .SelectFirstBusinessCar();

            CarBooking carBooking = new CarBooking(Driver)
                .InputDaysQuantity(RandomGenerator.GetRandomDaysQuantity())
                .ClickOrderButton()
                .GoToCheckout();

            Checkout checkout = new Checkout(Driver)
                .WriteBookingInfo(BookingInfoCreater.RightBookingInfo())
                .SubmitCheckout();

            Assert.IsTrue((new Regex(@"(\w*)success")).IsMatch(Driver.Url));
        }
    }
}
