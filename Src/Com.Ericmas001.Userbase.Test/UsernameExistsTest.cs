﻿using Com.Ericmas001.Userbase.Models.ServiceInterfaces;
using Com.Ericmas001.Userbase.Test.Util;
using FluentAssertions;
using Unity;
using Xunit;

namespace Com.Ericmas001.Userbase.Test
{

    [Collection("Com.Ericmas001.Userbase.Test")]
    public class UsernameExistsTest
    {
        [Fact]
        public void WithNoUserReturnsFalse()
        {
            // Arrange
            var util = new UserbaseSystemUtil(delegate { });

            // Act
            var result = util.Container.Resolve<IUserObtentionService>().UsernameExists(Values.UsernameSpongeBob);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void WithInvalidUserReturnsFalse()
        {
            // Arrange
            var util = new UserbaseSystemUtil(delegate (IUserbaseDbContext model)
            {
                model.Users.Add(Values.UserSpongeBob);
            });

            // Act
            var result = util.Container.Resolve<IUserObtentionService>().UsernameExists(Values.UsernameDora);

            // Assert
            result.Should().BeFalse();
        }
        [Fact]
        public void WithValidUserReturnsTrue()
        {
            // Arrange
            var util = new UserbaseSystemUtil(delegate (IUserbaseDbContext model)
            {
                model.Users.Add(Values.UserSpongeBob);
            });


            // Act
            var result = util.Container.Resolve<IUserObtentionService>().UsernameExists(Values.UsernameSpongeBob);

            // Assert
            result.Should().BeTrue();
        }
    }
}
