﻿using System.Linq;
using Com.Ericmas001.Userbase.Test.Util;
using NUnit.Framework;

namespace Com.Ericmas001.Userbase.Test
{
    [TestFixture]
    public class ManagementTest
    {

        [Test]
        public void PurgeConnectionTokens()
        {
            // Arrange

            var model = Values.Context;
            var expiredToken = Values.ExpiredToken;
            var validToken = Values.ValidToken;
            UserbaseSystem.Init(Values.Salt, contextGenerator: delegate
            {
                model.UserTokens.Add(expiredToken);
                model.UserTokens.Add(validToken);
                return model;
            });

            // Act
            UserbaseSystem.PurgeConnectionTokens();

            // Assert
            Assert.AreEqual(validToken, model.UserTokens.Single());
        }

        [Test]
        public void PurgeRecoveryTokens()
        {
            // Arrange

            var model = Values.Context;
            var expiredRecoveryToken = Values.ExpiredRecoveryToken;
            var validRecoveryToken = Values.ValidRecoveryToken;
            UserbaseSystem.Init(Values.Salt, contextGenerator: delegate
            {
                model.UserRecoveryTokens.Add(expiredRecoveryToken);
                model.UserRecoveryTokens.Add(validRecoveryToken);
                return model;
            });

            // Act
            UserbaseSystem.PurgeRecoveryTokens();

            // Assert
            Assert.AreEqual(validRecoveryToken, model.UserRecoveryTokens.Single());
        }

        [Test]
        public void PurgeUsers()
        {
            // Arrange

            var model = Values.Context;
            var activeUser = Values.UserSpongeBob;
            var inactiveUser = Values.UserDora;
            inactiveUser.Active = false;
            UserbaseSystem.Init(Values.Salt, contextGenerator: delegate
            {
                model.Users.Add(activeUser);
                model.Users.Add(inactiveUser);
                return model;
            });

            // Act
            UserbaseSystem.PurgeUsers();

            // Assert
            Assert.AreEqual(activeUser, model.Users.Single());
        }
    }
}
