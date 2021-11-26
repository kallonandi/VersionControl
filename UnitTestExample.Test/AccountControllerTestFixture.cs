﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
    TestCase("irf@uni-corvinus", false),
    TestCase("irf.uni-corvinus.hu", false),
    TestCase("irf@uni-corvinus.hu", true)

        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            //Arrange
            var accountController = new AccountController();

            //Act
            var result =accountController.ValidateEmail(email);

            //Assert
            Assert.AreEqual(result, expectedResult);
        }
        [
            Test,
            TestCase("abcd1234",false),
            TestCase("ABCD1234",false),
            TestCase("abcdABCD",false),
            TestCase("abCD12",false),
            TestCase("abCD1234", true)

            
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            //Arrange
            var accountController = new AccountController();

            //Act
            var result = accountController.ValidatePassword(password);

            //Assert
            Assert.AreEqual(expectedResult,result );
        }

        [Test,
            TestCase("irf@uni-corvinus.hu", "Abcd1234"),
    TestCase("irf@uni-corvinus.hu", "Abcd1234567"),
            ]
        public void TestRegisterHappyPath(string email,string password)
        {
            var AccountController = new AccountController();
            var result = AccountController.Register(email, password);
            Assert.AreEqual(email, result.Email);
            Assert.AreEqual(password, result.Password);
            Assert.AreNotEqual(Guid.Empty, result.ID);
        }
    }

}
